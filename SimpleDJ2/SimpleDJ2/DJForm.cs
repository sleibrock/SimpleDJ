using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// the BassNet DLL is in the ./bin/debug folder
// if the solution doesn't add that itself
// then you'll have to add it manually
// When distributing, distribute with ALL BASS DLL files
using Un4seen.Bass;
using Un4seen.Bass.Misc;

namespace SimpleDJ2
{
    public partial class DJForm : Form
    {

        private Mixer mix;
        private string boxString = "No items added";
        private char[] sep = {'\\'}; // used to split file names

        private delegate void DelegateOpenFile(String s);           // type
        private DelegateOpenFile m_DelegateOpenFile;                // instance

        private WaveForm WFLeft = null; // waveform good stuff
        private WaveForm WFRight = null;

        // Instantiation, FormLoad, FormClosing, DragDrop
        public DJForm()
        {
            InitializeComponent();
            this.AllowDrop = true;//allow drops in Win Form
            //this.playlistBox.AllowDrop = true; //Apparently we can't drop in the filebox area.......
            this.DragEnter += new DragEventHandler(DJForm_DragEnter);//Set DragEnter handler
            this.DragDrop += new DragEventHandler(DJForm_DragDrop);//Set DragDrophandler
            
        }

        private void DJForm_Load(object sender, EventArgs e)
        {
            // load all the details into here?
            mix = new Mixer();

            // start the timer onload
            timer.Enabled = true;

            // add the default noitems string
            playlistBox.Items.Add(boxString);

            reset();
        }

        private void DJForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mix.clean();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (mix.running())
            {
                if (mix.deckARunning())
                {
                    // insert the time stamps
                    timeDeckA.Text = mix.getTimeDeck('A');
                }
                if (mix.deckBRunning())
                {
                    timeDeckB.Text = mix.getTimeDeck('B');
                }
            }
        }

        private void reset()
        {
            // everything is in multiples of 100s basically
            // use this for when you want to reset the sliders
            faderDeckA.Value = 600;
            faderDeckB.Value = 600;
            crossFader.Value = 500;
        }

        private string getItem()
        {
            // get the item out of the playlistBox
            if (playlistBox.SelectedItem != null)
            {
                if (!playlistBox.SelectedItem.Equals(string.Empty))
                {
                    return playlistBox.SelectedItem.ToString();
                }
            }
            return string.Empty;
        }

        // Waveform Drawing procedures here
        private void LeftCallback(int framesDone, int framesTotal, TimeSpan elapsedTime, bool finished)
        {
            // will be called during rendering...
            DrawWaveLeft();
        }

        private void DrawWaveLeft()
        {
            if (WFLeft != null)
                deckAOsc.BackgroundImage = WFLeft.CreateBitmap(deckAOsc.Width, deckAOsc.Height, -1, -1, false);
            else
                deckAOsc.BackgroundImage = null;
        }

        private void RightCallback(int framesDone, int framesTotal, TimeSpan elapsedTime, bool finished)
        {
            // will be called during rendering...
            DrawWaveRight();
        }

        private void DrawWaveRight()
        {
            if (WFRight != null)
                deckBOsc.BackgroundImage = WFRight.CreateBitmap(deckBOsc.Width, deckBOsc.Height, -1, -1, false);
            else
                deckBOsc.BackgroundImage = null;
        }

        // Loading Songs into the Decks
        private void loadDeckA_Click(object sender, EventArgs e)
        {
            if (mix.running())
            {
                string item = getItem();
                if (!item.Equals(string.Empty) || item != null)
                {
                    if (mix.loadDeckA(item))
                    {
                        // the deck loaded, so let's make a waveform
                        WFLeft = new WaveForm(item, new Un4seen.Bass.Misc.WAVEFORMPROC(LeftCallback), deckAOsc);
                        WFLeft.CallbackFrequency = 500; // every 10 seconds rendered
                        WFLeft.ColorBackground = Color.Black;
                        WFLeft.ColorBeat = Color.Lime;
                        WFLeft.ColorVolume = Color.Red;
                        WFLeft.RenderStart(true, BASSFlag.BASS_DEFAULT);

                        deckALabel.Text = item.Split(sep).Last();
                        timeDeckA.Text = mix.getTimeDeck('A');
                        mix.computeCrossFade();
                    }
                }
                else
                {
                    Console.WriteLine("Could not load into Deck A");
                }
            }
        }

        private void loadDeckB_Click(object sender, EventArgs e)
        {
            if (mix.running())
            {
                string item = getItem();
                if (!item.Equals(string.Empty) || item != null)
                {
                    if (mix.loadDeckB(item))
                    {
                        WFRight = new WaveForm(item, new Un4seen.Bass.Misc.WAVEFORMPROC(RightCallback), deckAOsc);
                        WFRight.CallbackFrequency = 500; // every 10 seconds rendered
                        WFRight.ColorBackground = Color.Black;
                        WFRight.ColorBeat = Color.Lime;
                        WFRight.ColorVolume = Color.Red;
                        WFRight.RenderStart(true, BASSFlag.BASS_DEFAULT);

                        deckBLabel.Text = item.Split(sep).Last();
                        timeDeckB.Text = mix.getTimeDeck('B');
                        mix.computeCrossFade();
                    }
                }
                else
                {
                    Console.WriteLine("Could not load into Deck A");
                }
            }
        }

        // Playing and pausing the decks
        private void playDeckA_Click(object sender, EventArgs e)
        {
            if (mix.running())
            {
                // hopefully a deck is loaded
                mix.playDeckA();
            }
        }

        private void playDeckB_Click(object sender, EventArgs e)
        {
            if (mix.running())
            {
                mix.playDeckB();
            }
        }

        // Events for form elements
        // All sliders are in range of (0-1000)
        private void faderDeckA_ValueChanged(object sender, EventArgs e)
        {
            float v = float.Parse(faderDeckA.Value.ToString());
            v /= 1000.0f; // scale it down
            mix.setGainDeckA(v);
        }

        private void faderDeckB_ValueChanged(object sender, EventArgs e)
        {
            float v = float.Parse(faderDeckB.Value.ToString());
            v /= 1000.0f; // scale it down
            mix.setGainDeckB(v);
        }

        private void crossFader_ValueChanged(object sender, EventArgs e)
        {
            float v = float.Parse(crossFader.Value.ToString());
            v /= 1000.0f; // scale it down
            Console.WriteLine(v.ToString());
            mix.setCrossFade(v);
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (playlistBox.Items.Contains(boxString))
                {
                    playlistBox.Items.Clear();
                }
                playlistBox.Items.Add(dlg.FileName);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string item = getItem();
            if (!item.Equals(boxString))
            {
                playlistBox.Items.Remove(item);
            }
            playlistBox.SelectedItem = null; // don't select anything
        }

        // FEATURES
        private void saveButton_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(/*Current Directory + */"DJsave.txt"); //open the file for writing.
            //this.playlistBox.Items.Add(Directory.GetCurrentDirectory());
            foreach (string file in this.playlistBox.Items)
            { 
                writer.WriteLine(file); //write the filepath to the file.
            }
            writer.Close(); //close the file.
            writer.Dispose(); //dispose it from the memory.
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Stream fileStream = File.Open("DJsave.txt", FileMode.Open);//open file
            StreamReader reader = new StreamReader(fileStream);//create a reader for the file
            string line = null;//create buffer
            do
            {
                line = reader.ReadLine();// get the next line from the file

                if (line == null)
                {
                    break;// there are no more lines; break out of the loop
                }

                this.playlistBox.Items.Add(line);//Add files to list
                this.playlistBox.Items.Remove("No items added");//Remove "No items added"

            } while (true);

        }

        private void playlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DJForm_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;//Enable data drop.
        }


        private void DJForm_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {

            bool inst = true;//file in list bool

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);//get data from drop

            foreach (string file in files)//read all of the dropped data
            {
                foreach (string filein in this.playlistBox.Items)//compare dropped data to songs in list
                {
                    if (file == filein)//Is the file already in the list?
                    {
                        inst = false;//Yes, dont add it.
                    }
                        
                }
                if (inst)//No.
                {
                    this.playlistBox.Items.Add(file);//Add it.
                    this.playlistBox.Items.Remove("No items added");//Remove "No items added"
                }
            }
        }

        private void deckBOsc_Click(object sender, EventArgs e)
        {

        }

        private void timeDeckB_Click(object sender, EventArgs e)
        {

        }

        private void timeDeckA_Click(object sender, EventArgs e)
        {

        }

        private void crossFader_Scroll(object sender, EventArgs e)
        {

        }

        private void faderDeckB_Scroll(object sender, EventArgs e)
        {

        }

        private void faderDeckA_Scroll(object sender, EventArgs e)
        {

        }

        private void deckAOsc_Click(object sender, EventArgs e)
        {

        }

    }
}
