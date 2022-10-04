using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System.Reflection.PortableExecutable;

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
    PdfDocument document = PdfReader.Open(path + "\\" + e.Name, "");

    PdfSecuritySettings securitySettings = document.SecuritySettings;

    // Setting one of the passwords automatically sets the security level to 
    // PdfDocumentSecurityLevel.Encrypted128Bit.
    securitySettings.UserPassword = "abc123";
    //securitySettings.OwnerPassword = "abc123";

    // Don't use 40 bit encryption unless needed for compatibility reasons
    //securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;

    // Restrict some rights.
    //securitySettings.PermitAccessibilityExtractContent = false;
    //securitySettings.PermitAnnotations = false;
    //securitySettings.PermitAssembleDocument = false;
    //securitySettings.PermitExtractContent = false;
    //securitySettings.PermitFormsFill = false;
    //securitySettings.PermitFullQualityPrint = false;
    //securitySettings.PermitModifyDocument = false;
    //securitySettings.PermitPrint = true;

    // Save the document...
    document.Save(path + "\\" + e.Name);
}


