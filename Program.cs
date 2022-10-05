using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System.Reflection.PortableExecutable;
// PDFsharp is published under the MIT/LGPL License

FileSystemWatcher watcher = new FileSystemWatcher();
    watcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\";
    watcher.Filter = "*.pdf";
    watcher.IncludeSubdirectories = true;
    watcher.Created += new FileSystemEventHandler(fw_Created);
    watcher.EnableRaisingEvents = true;
    System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

static void fw_Created(object sender, FileSystemEventArgs e)
{
    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents";
    using (PdfDocument document = PdfReader.Open(path + "\\" + e.Name, ""))
    {
         PdfSecuritySettings securitySettings = document.SecuritySettings;
        // Setting one of the passwords automatically sets the security level to 
        // PdfDocumentSecurityLevel.Encrypted128Bit.
        securitySettings.UserPassword = "abc123";
        // Save the document...
        document.Save(path + "\\" + e.Name);
        Console.WriteLine($"Password applied: {e.Name}");
    }
    
}


