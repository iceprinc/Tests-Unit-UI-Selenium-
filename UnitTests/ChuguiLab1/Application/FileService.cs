using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Application
{
    public class FileService
    {
        public int RemoveTemporaryFiles(string dir)
        {
            if (Directory.Exists(dir))
            {
                string readPath;
                if (dir.EndsWith("\\"))
                {
                    readPath = dir + "ToRemove.txt";
                }
                else
                {
                    readPath = dir + "\\ToRemove.txt";
                }
                if (File.Exists(readPath))
                {
                    StreamReader reader = new StreamReader(readPath, Encoding.Default);
                    string fileName = "";
                    int delBytes = 0;
                    while (fileName != null)
                    {
                        fileName = reader.ReadLine();
                        if (fileName == null)
                            break;
                        string deletePath;
                        if (dir.EndsWith("\\"))
                        {
                            deletePath = dir + fileName;
                        }
                        else
                        {
                            deletePath = dir + "\\" + fileName;
                        }
                        if (File.Exists(deletePath))
                        {
                            FileInfo fi = new FileInfo(deletePath);
                            delBytes += Convert.ToInt32(fi.Length);
                            File.Delete(deletePath);
                        }
                        else
                        {
                            string errorLogPath;
                            if (dir.EndsWith("\\"))
                            {
                                errorLogPath = dir + "error.log";
                            }
                            else
                            {
                                errorLogPath = dir + "\\" + "error.log";
                            }
                            StreamWriter writer = new StreamWriter(errorLogPath, true, Encoding.Default);
                            writer.WriteLine($"Файл '{fileName}' не был найден!");
                            writer.Close();
                        }
                    }
                    reader.Close();
                    return delBytes;
                }
                else
                {
                    throw new Exception($"В заданной директории не найден файл 'ToRemove.txt'");
                }
            }
            else
            {
                throw new Exception($"Директория '{dir}' не найдена!");
            }
        }
    }
}
