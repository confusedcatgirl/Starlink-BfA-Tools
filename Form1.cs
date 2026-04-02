using System.Text;

namespace LocPackBinReader {
    public partial class MainForm : Form {

        int[] locHeader = { 0, 0 };
        int linepos = 0;
        string used_file = "";
        List<object[]> data = new List<object[]>(); // Guid, string, int, int, byte[]

        public MainForm() {
            InitializeComponent();
            log.Items.Clear();
        }

        private void tree_click(object sender, EventArgs e) {
            var _line = tree.SelectedNode.Text.Split(" - ");
            id_viewer.Text = _line[1];
            pos_viewer.Text = _line[0];
            text_editor.Text = _line[2];
        }

        private void open_item_Click(object sender, EventArgs e) {
            tree.Nodes.Clear();
            data.Clear();

            OpenFileDialog file_dia = new OpenFileDialog();
            file_dia.Filter = "Localization Files|*.locpackbin";
            file_dia.Multiselect = false;
            file_dia.Title = "Select locpackbin...";

            if (file_dia.ShowDialog() == DialogResult.OK) {
                FileFromBinary(file_dia.FileName);
                used_file = file_dia.FileName;
            }
        }

        private static class LocPackLines {
            // First two lines from each .locpack
            private static readonly HashSet<(int, int)> Menus =
            [
                (6, 30887), // Avatar: Frontiers of Pandora
                (6, 17106), // Star Wars: Outlaws
                (1, 7985 )  // Starlink: Battle for Atlas
            ];

            private static readonly HashSet<(int, int)> Subtitles =
            [
                (7, 65565), // Avatar: Frontiers of Pandora
                (8, 98265), // Star Wars: Outlaws
                (1, 15591)  // Starlink: Battle for Atlas
            ];

            public static bool IsMenus(int line1, int line2) => Menus.Contains((line1, line2));
            public static bool IsSubtitles(int line1, int line2) => Subtitles.Contains((line1, line2));
        }

        #region ToBin
        public void FileToBin(List<object[]> data) {
            try {

                using (var writer = new BinaryWriter(new FileStream(Path.ChangeExtension(used_file, ".locpackbiner"), FileMode.Create))) {
                    // Write Header
                    writer.Write(locHeader[0]);
                    writer.Write(locHeader[1]);

                    foreach (var line in data) {
                        // Write Entry
                        // 16 Bytes of GUID
                        // 4 Bytes of Null
                        // 2 Bytes of Length
                        // X Bytes of String
                        WriteLine(writer, line);
                    }

                    writer.Close();
                }

                log.Items.Add($"Saved {used_file}");
            } catch (Exception ex) {
                log.Items.Add($"Failed to save file: {used_file} - {ex.Message}");
            }
        }

        private void WriteLine(BinaryWriter writer, object[] line) {
            
            // All the variables have to be casted or .NET will complain
            // Convert all data to Byte Arrays
            byte[] _length = BitConverter.GetBytes((int)line[2]);
            byte[] guid = GetGuidBytes((Guid)line[0]);
            byte[] text = Encoding.Default.GetBytes((string)line[1]);
            byte[] _n = BitConverter.GetBytes((int)line[4]);

            writer.Write(guid[0..16]);
            writer.Write(_n);
            // I have no fucking idea why it wants it like that, but in any other case it will freak out
            writer.Write(_length[0]);
            writer.Write(_length[1]);
            writer.Write(text);
        }

        private static byte[] GetGuidBytes(Guid guid) {
            byte[] bytes = guid.ToByteArray();
            byte[] newBytes = new byte[16];

            Array.Copy(bytes, 6, newBytes, 0, 2); // Group 3
            Array.Copy(bytes, 4, newBytes, 2, 2); // Group 2
            Array.Copy(bytes, 0, newBytes, 4, 4); // Group 1
                                                  // Group 5 - Reversed
            Array.Copy(bytes, 10, newBytes, 8, 6);
            Array.Reverse(newBytes, 8, 6);
            // Group 4 - Reversed
            Array.Copy(bytes, 8, newBytes, 14, 2);
            Array.Reverse(newBytes, 14, 2);

            return newBytes;
        }
        #endregion

        #region FromBin
        public void FileFromBinary(string path) {
            try {
                using var reader = new BinaryReader(new FileStream(path, FileMode.Open));
                linepos = 0;

                // Read and store the first two lines (8 bytes)
                int locNull = reader.ReadInt32();
                int locSize = reader.ReadInt32();
        
                locHeader = [locNull, locSize];
                progress.Value = 0;
                progress.Maximum = locSize;
                log.Items.Add($"Loading...");
                log.Update();

                while (reader.BaseStream.Position < reader.BaseStream.Length) {
                    object[] line = ReadLine(reader, linepos);

                    var node = line[3].ToString() + " - " + line[0].ToString() + " - " + line[1];
                    data.Add(line);
                    tree.Nodes.Add(node);

                    linepos++;
                    progress.Value++;
                }

                log.Items.Add($"File Loaded: {Path.GetFileName(path)} ");
            } catch (Exception ex) {
                log.Items.Add($"Failed to load file: {Path.GetFileName(path)} - {ex.Message}");
            }
        }

        private static object[] ReadLine(BinaryReader reader, int pos) {
            Guid guid = ReadGuid(reader);

            byte[] _null = reader.ReadBytes(4);
            int length = BitConverter.ToInt16(reader.ReadBytes(2));

            // Read out X bytes
            byte[] data = reader.ReadBytes(length);

            // Convert into String
            string text = Encoding.Default.GetString(data);

            return [guid, text, length, pos, _null];
        }

        private static Guid ReadGuid(BinaryReader reader) {
            byte[] bytes = reader.ReadBytes(16);
            byte[] newBytes = new byte[16];

            Array.Copy(bytes, 4, newBytes, 0, 4); // Group 1
            Array.Copy(bytes, 2, newBytes, 4, 2); // Group 2
            Array.Copy(bytes, 0, newBytes, 6, 2); // Group 3
                                                  // Group 4 - Reversed
            Array.Copy(bytes, 14, newBytes, 8, 2);
            Array.Reverse(newBytes, 8, 2);
            // Group 5 - Reversed
            Array.Copy(bytes, 8, newBytes, 10, 6);
            Array.Reverse(newBytes, 10, 6);

            return new Guid(newBytes);
        }

        #endregion

        private void save_button_Click(object sender, EventArgs e) {
            string _data = pos_viewer.Value.ToString() + " - " + id_viewer.Text + " - " + text_editor.Text;
            int pos = (int)pos_viewer.Value;

            tree.SelectedNode.Text = _data;
            data[pos] = [data[pos][0], text_editor.Text, text_editor.TextLength, data[pos][2], data[pos][3], data[pos][4]];
            log.Items.Add("Wrote new text to Index: " + pos_viewer.Value.ToString());
        }

        private void save_item_Click(object sender, EventArgs e) {
            FileToBin(data);
        }

        private void saveas_item_Click(object sender, EventArgs e) {

        }

        private void exit_item_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
