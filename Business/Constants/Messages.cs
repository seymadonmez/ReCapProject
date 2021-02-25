using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi!";
        public static string CarDeleted = "Araba silindi!";
        public static string CarUpdated = "Araba güncellendi!";


        public static string CarNameInvalid = "Araba ismi geçersiz!";
        public static string CarsListed = "Arabalar listelendi";
        public static string BrandsListed = "Araba modelleri listelendi";
        public static string BrandAdded = "Araba modeli eklendi";
        public static string BrandDeleted = "Marka silindi!";
        public static string BrandUpdated = "Marka güncellendi!";

        public static string BrandNameValid = "Marka ismi en az 2 karakter olmalıdır.";
        public static string CarPriceInvalid = "Araba fiyatı geçersiz fiyat 0'dan büyük olmalıdır.";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi!";
        public static string ColorUpdated = "Renk güncellendi!";
        public static string ColorsListed = "Renkler listelendi";

        public static string UserNameInvalid = "Kullanıcı ismi geçersiz! Kullanıcı ismi en az 2 karakter olmalıdır.";
        public static string UserDeleted = "Kullanıcı silindi!";
        public static string UserUpdated = "Kullanıcı güncellendi!";

        public static string RentalAdded = "Kiralama oluşturuldu";
        public static string RentalInvalid = "Araba teslim edilmediği için kiralanamaz";

        public static string MaintenanceTime = "Sistem bakımda";
    }
}
