using KZTool.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace KZTool
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private static int address_base = 0x1BC5898; // address_room, game ver 1.0.0

        // These get adjusted based on what version of the game is found
        private int address_room = 0x1BC5898; // base + 0
        private int address_setroom = 0x1BC589C; // base + 4

        GlobalHotkey hotkey_restart;
        GlobalHotkey hotkey_nextRoom;
        GlobalHotkey hotkey_lastRoom;
        GlobalHotkey hotkey_setRoom;

        

        Process game;


        // Form, hotkey processing in WndProc
        public Form1()
        {
            hotkey_restart = new GlobalHotkey(GlobalHotkey.Constants.NOMOD, Keys.R, this);
            hotkey_nextRoom = new GlobalHotkey(GlobalHotkey.Constants.NOMOD, Keys.F2, this);
            hotkey_lastRoom = new GlobalHotkey(GlobalHotkey.Constants.NOMOD, Keys.F1, this);
            hotkey_setRoom = new GlobalHotkey(GlobalHotkey.Constants.NOMOD, Keys.F5, this);

            // Registering hotkeys is done in timer_read_Tick, they will unregister if the game isn't open so they don't interfere in other apps

            InitializeComponent();
            populateRoomList();

            // Put GlobalHotkeys as tags on textbox components to make rebinding easier
            hotkeyHardReset.Tag = hotkey_restart;
            hotkeyNextRoom.Tag = hotkey_nextRoom;
            hotkeyPreviousRoom.Tag = hotkey_lastRoom;
            hotkeySetRoom.Tag = hotkey_setRoom;

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            hotkey_restart.Unregister();
            hotkey_nextRoom.Unregister();
            hotkey_lastRoom.Unregister();
            hotkey_setRoom.Unregister();
        }
        protected override void WndProc(ref Message m)
        {
            if (groupBox1 != null && groupBox1.Enabled)
            {
                if (m.Msg == GlobalHotkey.Constants.WM_HOTKEY_MSG_ID)
                {
                    if (m.WParam.ToInt32() == hotkey_restart.GetHashCode()) changeRoom(0);
                    else if (m.WParam.ToInt32() == hotkey_lastRoom.GetHashCode()) changeRoom(-1);
                    else if (m.WParam.ToInt32() == hotkey_nextRoom.GetHashCode()) changeRoom(1);
                    else if (m.WParam.ToInt32() == hotkey_setRoom.GetHashCode()) setToTextbox();
                }
            }
            base.WndProc(ref m);
        }



        // Memory
        private void changeRoom(int change)
        {
            int c = Memory.ReadInt(game, address_room);
            c += change;
            setRoom(c);
        }
        private void setRoom(int room)
        {
            if (timer_switchLock.Enabled)
                return;

            Memory.WriteInt(game, address_setroom, room);
            timer_switchLock.Enabled = true;
        }
        private void setToTextbox()
        {
            int r = 4;
            bool s = int.TryParse(textBox1.Text, out r);

            if (s)
                setRoom(r);
        }
        private void setGame(Process p)
        {

            game = p;

            // Identify version (this part is in dire need of cleanup, split into different functions)

            if (Memory.ReadInt(game, address_base + 4) == -1) label1.Text = "Found Katana ZERO 1.0.0 (Steam)";
            else if (Memory.ReadInt(game, address_base - 4160 + 4) == -1)
            {
                label1.Text = "Found Katana ZERO 1.0.0 (GoG)";
                address_room = address_base - 4160;
            }
            else if (Memory.ReadInt(game, address_base + 495440 + 4) == -1)
            {
                label1.Text = "Found Katana ZERO 1.0.3 Speedrun Beta (Steam)";
                address_room = address_base + 495440;
            }
            else if (Memory.ReadInt(game, address_base + 495440 - 4160 + 4) == -1)
            {
                label1.Text = "Found Katana ZERO 1.0.3 Speedrun Beta (GoG)";
                address_room = address_base + 495440 - 4160;
            }
            else if (Memory.ReadInt(game, address_base + 1249192 + 4) == -1)
            {
                label1.Text = "Found Katana ZERO 1.0.4 (Steam)";
                address_room = address_base + 1249192;
            }
            else if (Memory.ReadInt(game, address_base + 1249192 - 4160 + 4) == -1)
            {
                label1.Text = "Found Katana ZERO 1.0.4 (GoG)";
                address_room = address_base + 1249192 - 4160;
            }
            else if (Memory.ReadInt(game, address_base + 1257576 + 4) == -1)
            {
                label1.Text = "Found Katana ZERO 1.0.5 (Steam)";
                address_room = address_base + 1257576;
            }
            else
            {
                label1.Text = "Found game, but can't identify version";
                return;
            }

            address_setroom = address_room + 4;

            timer1.Enabled = false;
            timer_read.Enabled = true;

            updateCurrentRoom();

            groupBox1.Enabled = true;


        }

        // UI
        private void updateCurrentRoom() {
            var m = Memory.ReadInt(game, address_room);
            label2.Text = "Current Room: " + m;
        }
        private void buttonSetRoom_Click(object sender, EventArgs e)
        {
            setToTextbox();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                setToTextbox();
                //e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void populateRoomList()
        {
            string s = GetResourceTextFile("RoomList.xml");

            var doc = new XmlDocument();
            doc.LoadXml(s);

            ContextMenu menu = new ContextMenu();

            foreach ( XmlNode a in doc.ChildNodes.Item(1).ChildNodes )
            {

                if (a.LocalName == "Category")
                {

                    var newItem = menu.MenuItems.Add(a.FirstChild.InnerText);

                    AddRoomCategory(newItem, a.ChildNodes);
                }

            }

            buttonRoomList.Click += (sender, args) => menu.Show(buttonRoomList, buttonRoomList.PointToClient(Cursor.Position));

        }
        private void AddRoomCategory(MenuItem item, XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                if (node.FirstChild.InnerText != item.Text)
                {
                    var newItem = item.MenuItems.Add(node.FirstChild.InnerText);

                    if (node.LocalName == "Category") AddRoomCategory(newItem, node.ChildNodes);
                    else if (node.LocalName == "Room")
                    {
                        newItem.Click += new EventHandler(roomListPressed);

                        int ii = -1;
                        int.TryParse(node.ChildNodes.Item(1).InnerText, out ii);
                        newItem.Tag = ii;
                    }
                }
            }
        }
        private void roomListPressed(object sender, EventArgs e)
        {
            textBox1.Text = ((int)(((MenuItem)sender).Tag)).ToString();
            setToTextbox();
        }

        // Timers
        private void timer_findgame_Tick(object sender, EventArgs e)
        {
            // Timer runs when game process has not been found

            Process[] pname = Process.GetProcessesByName("Katana ZERO");
            if (pname.Length != 0) setGame(pname[0]);
        }
        private void timer_read_Tick(object sender, EventArgs e)
        {
            if (GetActiveWindowTitle() == "Katana ZERO")
            {
                hotkey_restart.Register();
                hotkey_nextRoom.Register();
                hotkey_lastRoom.Register();
                hotkey_setRoom.Register();
            } else
            {
                hotkey_restart.Unregister();
                hotkey_nextRoom.Unregister();
                hotkey_lastRoom.Unregister();
                hotkey_setRoom.Unregister();
            }

            if (!game.HasExited)
            {
                var roome = Memory.ReadInt(game, address_room);
                updateCurrentRoom();

                if (roome < 4) setRoom(4);

            } else
            {
                label1.Text = "Katana ZERO is not running";
                groupBox1.Enabled = false;
                timer1.Enabled = true;
                timer_read.Enabled = false;
            }
        }
        private void Timer_switchLock_Tick(object sender, EventArgs e)
        {
            timer_switchLock.Enabled = false;
        }



        // Utility
        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        public string GetResourceTextFile(string filename)
        {
            string result = string.Empty;

            using (Stream stream = this.GetType().Assembly.
                       GetManifestResourceStream("KZTool." + filename))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }


        private void Hotkey_MouseDown(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        private void Hotkey_KeyDown(object sender, KeyEventArgs e)
        {
            bool isLetterOrDigit = char.IsLetterOrDigit((char)e.KeyCode);

            if (isLetterOrDigit)
            {
                // Format modifier text and generate modifier int for hotkey construction
                string mod = "";
                int imod = 0x0;

                if (e.Modifiers.ToString() != "None")
                {
                    mod = e.Modifiers.ToString().Replace(",", " +") + " + ";

                    foreach (var m in e.Modifiers.ToString().Replace(" ", "").Split(','))
                    {
                        if (m == "Control") imod += GlobalHotkey.Constants.CTRL;
                        else if (m == "Alt") imod += GlobalHotkey.Constants.ALT;
                        else if (m == "Shift") imod += GlobalHotkey.Constants.SHIFT;
                    }
                }

                GlobalHotkey hotkey = (GlobalHotkey)(((TextBox)sender).Tag); // Textboxes are tagged with corresponding GlobalHotkey in Form1 constructor

                hotkey.ChangeBind(imod, e.KeyCode);

                ((TextBox)sender).Text = mod + e.KeyCode;
            }
        }

    }
}
