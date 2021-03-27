using Core.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string BrandNameInvalid="Girilen isim 2 karakterden fazla olmalı";
        public static string BrandAdded="Marka başarılıyla eklendi";
        public static string CarImageAdded="Araba resmi başarıyla eklendi";
        public static string CarImageUpdated="Araba resmi başarıyla güncellendi";
        public static string CarImageDeleted="Araba resmi başarıyla silindi";
        public static string MaxCarImageError="Bir araba en fazla 5 resime sahip olabilir";
        public static string UserRegistered="Kayıt başarıyla gerçekleşti";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string PasswordError="Hatalı Parola";
        public static string SuccessfulLogin="Giriş Başarılı";
        public static string UserAlreadyExists="Kullanıcı Mevcut";
        public static string AccessTokenCreated="Token Oluşturuldu";
    }
}
