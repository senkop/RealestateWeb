//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using System.IO;


//namespace Try.BL.Helper
//{
//    public static class UploadFileHelper
//    {

//    //    public static string UploadImage(IFormFile FileUrl, string FolderPath)
//    //    {

//    //        // Get Directory
//    //        string FilePath = Directory.GetCurrentDirectory() + "/Images/ApartmentImages/" + FolderPath;

//    //        // Get File Name
//    //        string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);

//    //        // Merge The Directory With File Name
//    //        string FinalPath = Path.Combine(FilePath, FileName);

//    //        // Save Your File As Stream "Data Overtime"
//    //        using (var Stream = new FileStream(FinalPath, FileMode.Create))
//    //        {
//    //            FileUrl.CopyTo(Stream);
//    //        }

//    //        return FileName;
//    //    }

//    //    public static void RemoveFile(string FolderName , string RemovedFileName)
//    //    {
//    //        if (File.Exists(Directory.GetCurrentDirectory() + "/Images/ApartmentImages/" + FolderName + RemovedFileName))
//    //        {
//    //            File.Delete(Directory.GetCurrentDirectory() + "/Images/ApartmentImages/" + FolderName + RemovedFileName);
//    //        }

//    //    }
//    //}

//}

