using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

using Un4seen.Bass;
using Un4seen.Bass.AddOn.Mix;
using Un4seen.Bass.Misc;

namespace SimpleDJ2
{
    public class Mixer
    {
        public bool _isItLoaded = false; // check if the audio/library works

        private string _songA = string.Empty;
        private string _songB = string.Empty;

        private int _deckA = 0; // song stream pointers
        private int _deckB = 0; 

        // volume/crossfade information
        private float _crossFader;
        private float _deckAGain;
        private float _deckBGain;

        private bool _aRunning = false;
        private bool _bRunning = false;

        private int _mixer; // the mixing stream
        private Visuals _vis; // the visualization class

        public Mixer()
        {
            startDSP();
        }

        public void startDSP()
        {
            // Try to start the DSP
            // possible errors may include faulty audio drives/hardware, or restricted hardware access
            // or maybe the library just isn't there, or isn't working
            try
            {
                _isItLoaded = Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            }
            catch (Exception E)
            {
                Console.WriteLine(E.ToString());
            }

            if (running())
            {
                // the basic functionality here for construction of the mixer
                // try to use floating point sampling (if hardware can even do it)
                _mixer = BassMix.BASS_Mixer_StreamCreate(44100, 2, BASSFlag.BASS_SAMPLE_FLOAT);
                _vis = new Visuals();

                Bass.BASS_ChannelPlay(_mixer, false);
            }
        }

        public bool running()
        {
            // return if the DSP successfully started
            return _isItLoaded;
        }

        private string getTime(int channel)
        {
            // Format the string of "elapsed time / totaltime"
            long len = Bass.BASS_ChannelGetLength(channel); // get length of song
            long pos = Bass.BASS_ChannelGetPosition(channel); // get position in the song

            double totaltime = Bass.BASS_ChannelBytes2Seconds(channel, len);
            double elapsedtime = Bass.BASS_ChannelBytes2Seconds(channel, pos);

            int minutes1 = Convert.ToInt16(elapsedtime / 60.0);
            int seconds1 = Convert.ToInt16(elapsedtime % 60.0);
            int minutes2 = Convert.ToInt16(totaltime / 60.0);
            int seconds2 = Convert.ToInt16(totaltime % 60.0);
            // not sure if it's silly to recreate lots of timespans
            TimeSpan left = new TimeSpan(0, minutes1, seconds1);
            TimeSpan right = new TimeSpan(0, minutes2, seconds2);
            return left.ToString() + " | " + right.ToString();
        }

        public string getTimeDeck(char deck)
        {
            if (running())
            {
                if (deck.Equals('A'))
                {
                    if (_deckA != 0)
                    {
                        return getTime(_deckA);
                    }
                }
                else if (deck.Equals('B'))
                {
                    if (_deckB != 0)
                    {
                        return getTime(_deckB);
                    }
                }
            }
            return string.Empty;
        }

        public bool loadDeckA(string songName)
        {
            if (running())
            {
                if (!songName.Equals(string.Empty))
                {
                    _songA = songName;
                    _deckA = Bass.BASS_StreamCreateFile(songName, 0, 0, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT);
                    _aRunning = false; // definitely not playing
                    bool b = BassMix.BASS_Mixer_StreamAddChannel(_mixer, _deckA, BASSFlag.BASS_DEFAULT);
                    BassMix.BASS_Mixer_ChannelPause(_deckA); // pause when loaded
                    return b;
                }
            }
            return false;
        }

        public bool loadDeckB(string songName)
        {
            if (running())
            {
                if (!songName.Equals(string.Empty))
                {
                    _songB = songName;
                    _deckB = Bass.BASS_StreamCreateFile(songName, 0, 0, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT);
                    _bRunning = false; // definitely not playing
                    bool b = BassMix.BASS_Mixer_StreamAddChannel(_mixer, _deckB, BASSFlag.BASS_DEFAULT);
                    BassMix.BASS_Mixer_ChannelPause(_deckB); // pause as soon as it loads
                    return b;
                }
            }
            return false;
        }

        public void playDeckA()
        {
            Console.WriteLine(_deckA);
            if (running())
            {
                if (_deckA != 0)
                {
                    if (_aRunning)
                    {
                        _aRunning = false;
                        BassMix.BASS_Mixer_ChannelPause(_deckA);
                    }
                    else
                    {
                        _aRunning = true;
                        BassMix.BASS_Mixer_ChannelPlay(_deckA);
                    }
                }
            }
        }

        public void playDeckB()
        {
            Console.WriteLine(_deckB);
            if (running())
            {
                if (_deckB != 0)
                {
                    if (_bRunning)
                    {
                        _bRunning = false;
                        BassMix.BASS_Mixer_ChannelPause(_deckB);
                    }
                    else
                    {
                        _bRunning = true;
                        BassMix.BASS_Mixer_ChannelPlay(_deckB);
                    }
                }
            }
        }

        // deck running interface
        public bool deckARunning()
        {
            return _aRunning;
        }

        public bool deckBRunning()
        {
            return _bRunning;
        }

        // Volume/Gain/Crossfade section
        public void setGainDeckA(float gain)
        {
            _deckAGain = gain;
            computeCrossFade();
        }

        public void setGainDeckB(float gain)
        {
            _deckBGain = gain;
            computeCrossFade();
        }

        private void setGain(int deck, float gain)
        {
            // annoying dsp code to write
            // each node is like a (value,time) pair
            BASS_MIXER_NODE[] nodes = {
                new BASS_MIXER_NODE(Bass.BASS_ChannelSeconds2Bytes(deck, 0d), gain), };
            BassMix.BASS_Mixer_ChannelSetEnvelope(deck, BASSMIXEnvelope.BASS_MIXER_ENV_VOL, nodes);
        }

        public void setCrossFade(float xfade)
        {
            _crossFader = xfade;
            computeCrossFade();
        }

        public void computeCrossFade()
        {
            if (running())
            {
                // do the crossfade calculations
                float lMul, rMul;
                lMul = Math.Abs(_crossFader - 1.0f);
                rMul = Math.Abs(_crossFader);
                float xfLeft = _deckAGain * lMul;
                float xfRight = _deckBGain * rMul;
                setGain(_deckA, xfLeft);
                setGain(_deckB, xfRight);
            }
        }
        
        // Garbage collection/memory managing methods
        public void clearDeckA()
        {
            // remove deck A, set to zero
            BassMix.BASS_Mixer_ChannelRemove(_deckA);
            Bass.BASS_StreamFree(_deckA);
            _deckA = 0;
        }

        public void clearDeckB()
        {
            // remove deck A, set to zero
            BassMix.BASS_Mixer_ChannelRemove(_deckB);
            Bass.BASS_StreamFree(_deckB);
            _deckB = 0;
        }

        public void clean()
        {
            if (_deckA != 0)
            {
                clearDeckA();
            }
            if (_deckB != 0)
            {
                clearDeckB();
            }
            if (_mixer != 0)
            {
                Bass.BASS_StreamFree(_mixer);
            }
            Bass.BASS_Free();
        }
    }
}
