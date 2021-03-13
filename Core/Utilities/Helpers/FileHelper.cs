using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }
            var result = CreationOfNewFilePath(file);
            File.Move(sourcepath, result);
            return result;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = CreationOfNewFilePath(file).ToString();
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string CreationOfNewFilePath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\uploads";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" +
                          DateTime.Now.Year + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }

    }
}
