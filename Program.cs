﻿using System.Reflection.PortableExecutable;
using UglyToad.PdfPig;

    FileSystemWatcher watcher = new FileSystemWatcher();
    watcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents\";
    watcher.Filter = "*.pdf";
    watcher.IncludeSubdirectories = true;
    //watcher.Created += new FileSystemEventHandler(fw_Created);
    watcher.Created += new FileSystemEventHandler(fw_PW);
    watcher.EnableRaisingEvents = true;
    System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

static void fw_Created(object sender, FileSystemEventArgs e)
{
    //string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents";
    //PdfDocument document = PdfReader.Open(path + "\\" + e.Name, "");

    //PdfSecuritySettings securitySettings = document.SecuritySettings;

    //// Setting one of the passwords automatically sets the security level to 
    //// PdfDocumentSecurityLevel.Encrypted128Bit.
    ////securitySettings.UserPassword = "yourUserPassword";
    //securitySettings.OwnerPassword = "yourOwnerPassword";

    //// Don't use 40 bit encryption unless needed for compatibility reasons
    ////securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;

    //// Restrict some rights.
    //securitySettings.PermitAccessibilityExtractContent = false;
    //securitySettings.PermitAnnotations = false;
    //securitySettings.PermitAssembleDocument = false;
    //securitySettings.PermitExtractContent = false;
    //securitySettings.PermitFormsFill = false;
    //securitySettings.PermitFullQualityPrint = false;
    //securitySettings.PermitModifyDocument = false;
    //securitySettings.PermitPrint = false;

    //// Save the document...
    //document.Save(path + "\\" + e.Name);
}


static void fw_PW(object sender, FileSystemEventArgs e)
{
    string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\documents";
    
    using (PdfDocument document = PdfDocument.Open(path + "\\" + e.Name, new ParsingOptions { Password = "abc123" }))
        ;

}