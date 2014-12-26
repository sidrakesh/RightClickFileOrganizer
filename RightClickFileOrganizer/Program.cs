using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Log;

namespace RightClickFileOrganizer
{
    class Program
    {
        static string[] videoExtensions = { ".mp4", ".avi", ".3g2", ".3gp", ".asf", ".asx", ".avi", ".flv", ".mkv",
                                       ".mov", ".mp4", ".mpg", ".rm", ".swf", ".vob", ".wmv", ".mts", ".rmvb" };
        static string[] imageExtensions = { ".bmp", ".jpg", ".jpeg", ".png", ".psd", ".pspimage", ".thm", 
                                       ".tif", ".yuv", ".ico" };
        static string[] audioExtensions = { ".aif", ".iff", ".m3u", ".m4a", ".mid", ".mp3", ".mpa", ".ra", 
                                       ".wav", ".wma" };
        static string[] textFileExtensions = { ".doc", ".docx", ".log", ".msg", ".pages", ".rtf", ".txt", 
                                          ".wpd", ".wps", ".sublime-package", ".odt", ".dot", ".dotx" };
        static string[] dataFileExtensions = { ".csv", ".dat", ".efx", ".gbr", ".key", ".pps", ".ppt", ".pptx",
                                          ".sdf", ".tax2010", ".vcf", ".xml", ".xps", ".ics" };
        static string[] developerExtensions = { ".c", ".class", ".cpp", ".cs", ".dtd", ".fla", ".java", ".m", 
                                           ".pl", ".py", ".pyc", ".in", ".out", ".h" };
        static string[] diskImageExtensions = { ".dmg", ".iso", ".toast", ".vcd" };
        static string[] compressedExtensions = { ".7z", ".deb", ".gz", ".pkg", ".rar", ".rpm", ".sit", ".sitx",
                                            ".tar.gz", ".zip", ".zipx", ".tar" };
        static string[] webExtensions = { ".asp", ".cer", ".csr", ".css", ".htm", ".html", ".js", ".jsp", ".php",
                                     ".rss", ".xhtml" };
        static string[] executableExtensions = { ".app", ".bat", ".cgi", ".com", ".exe", ".gadget", ".jar", 
                                            ".pif", ".vb", ".wsf" };
        static string[] pageLayoutExtensions = { ".indd", ".pct", ".pdf", ".qxd", ".qxp", ".rels", ".mobi", ".epub" };
        static string[] spreadSheetExtensions = { ".xls", ".xlr", ".xlsx" };
        static string[] vectorImageExtensions = { ".ai", ".drw", ".eps", ".ps", ".svg" };
        static string[] ignoreExtensions = { ".ini", ".db", ".rdp" };
        static string[] cSharpProjectExtensions = { ".csproj" };
        static string[] vsProjectExtensions = { ".sln" };

        static string videoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        static string imagePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        static string musicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        static string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string pdfPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PDF documents");
        static string dataDocPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data documents");
        static string codePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Codes");
        static string compressedPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Compressed");
        static string executablePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Programs and Executables");
        static string textPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Text Documents");
        static string webPagePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Web pages");
        static string spreadSheetPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Spreadsheets");
        static string vectorImagePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Vector images");

        static string getFileString(System.IO.FileInfo fi)
        {
            string extension = fi.Extension.ToLower();
            string newFilePath = "";

            if (videoExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(videoPath, fi.Name);
            }
            else if (imageExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(imagePath, fi.Name);
            }
            else if (audioExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(musicPath, fi.Name);
            }
            else if (pageLayoutExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(pdfPath, fi.Name);
            }
            else if (dataFileExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(dataDocPath, fi.Name);
            }
            else if (developerExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(codePath, fi.Name);
            }
            else if (compressedExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(compressedPath, fi.Name);
            }
            else if (executableExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(executablePath, fi.Name);
            }
            else if (textFileExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(textPath, fi.Name);
            }
            else if (spreadSheetExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(spreadSheetPath, fi.Name);
            }
            else if (webExtensions.Contains(extension))
            {
                string webPageDir = System.IO.Path.Combine(webPagePath, System.IO.Path.GetFileNameWithoutExtension(fi.FullName));
                newFilePath = System.IO.Path.Combine(webPageDir, fi.Name);
            }
            else if (vectorImageExtensions.Contains(extension))
            {
                newFilePath = System.IO.Path.Combine(vectorImagePath, fi.Name);
            }
            else if (ignoreExtensions.Contains(extension))
            {
                newFilePath = "ignore";
            }
            else if (extension.Equals(".tex"))
            {
                newFilePath = System.IO.Path.Combine(System.IO.Path.Combine(documentPath, "LaTeX"), fi.Name);
            }
            else if (extension.Equals(".tmp"))
            {
                newFilePath = System.IO.Path.Combine(System.IO.Path.Combine(documentPath, "Temp Files"), fi.Name);
            }
            //else if()

            return newFilePath;
        }

        static Logger logger;
        static string selectedPath = "";

        static void Main(string[] args)
        {
            logger = new Logger();
            logger.initializeLogger();

            if (args.Length >= 1)
            {
                selectedPath = args[0];
            }
            else
            {
                Environment.Exit(0);
            }
            // Get the root directory
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(selectedPath);

            // Get the files in the directory
            System.IO.FileInfo[] fileInfos = dirInfo.GetFiles("*.*");

            string displayResult = "";

            foreach (System.IO.FileInfo fileInfo in fileInfos)
            {
                string newFilePath = getFileString(fileInfo);

                if (newFilePath.Equals("ignore"))
                {
                    logger.InfoLog("Ignoring file " + fileInfo.FullName);
                    continue;
                }

                string currentDirectory = fileInfo.Directory.FullName;
                string extension = fileInfo.Extension;
                string nameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name);

                if (!newFilePath.Equals(""))
                {
                    string destDirectory = System.IO.Path.GetDirectoryName(newFilePath);

                    if (!System.IO.Directory.Exists(destDirectory))
                    {
                        System.IO.Directory.CreateDirectory(destDirectory);
                        logger.InfoLog("Destination directory " + destDirectory + " created");
                    }

                    if (!System.IO.File.Exists(newFilePath))
                    {
                        File.Move(fileInfo.FullName, newFilePath);

                        logger.InfoLog("Moved file " + fileInfo.FullName + " to " + newFilePath);

                        if (extension.Equals(".html"))
                        {
                            string resourceFolder = System.IO.Path.Combine(currentDirectory, nameWithoutExtension + "_files");
                            if (Directory.Exists(resourceFolder))
                            {
                                string destFolder = System.IO.Path.Combine(destDirectory, nameWithoutExtension + "_files");
                                Directory.Move(resourceFolder, destFolder);
                                logger.InfoLog("Moved resource directory " + destFolder + " for html page");
                            }
                        }
                    }
                    else
                    {
                        displayResult += "File '" + System.IO.Path.GetFileName(newFilePath) + "' already exists at destination '" + destDirectory + "'\n";
                        logger.FailureLog("File '" + System.IO.Path.GetFileName(newFilePath) + "' already exists at destination '" + destDirectory + "'");
                    }
                }
                else
                {
                    displayResult += "Encountered unresolved File " + fileInfo.Name + "\n";
                    logger.FailureLog("Encountered unresolved File " + fileInfo.Name);
                }
            }

            if (displayResult.Equals(""))
            {
                MessageBox.Show("All files moved successfully");
                logger.SuccessLog("All files moved successfully from " + selectedPath);
            }
            else
            {
                MessageBox.Show(displayResult + "Remaining files moved successfully!");
            }
        }
    }
}
