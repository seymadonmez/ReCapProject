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

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserNameInvalid = "Kullanıcı ismi geçersiz! Kullanıcı ismi en az 2 karakter olmalıdır.";
        public static string UserDeleted = "Kullanıcı silindi!";
        public static string UserUpdated = "Kullanıcı güncellendi!";

        public static string RentalAdded = "Kiralama oluşturuldu";
        public static string RentalInvalid = "Araba teslim edilmediği için kiralanamaz";
        public static string InvalidBrandId = "Marka bulanamadı";
        public static string InvalidColorId = "Renk bulanamadı";


        public static string MaintenanceTime = "Sistem bakımda";
        public static string ColorNameAlreadyExists="Bu isimde renk zaten mevcut";
        public static string BrandNameAlreadyExists = "Bu isimde renk zaten mevcut";

        public static string CarImageLimitExceded = "Araba resmi limiti aşıldığı için yeni resim eklenemiyor";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string NotCarAvailable = "Araba kiralanmaya uygun değil!";
        public static string CreditCardExists = "Kredi kartı kaydedilmiş";


    }
}
