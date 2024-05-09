﻿namespace PersonalWebSiteMVC.Web.ResultMessages
{
    public static class Messages
    {
        public static class Talent
        {
            public static string Add(string talentName)
            {
                return $"{talentName} başlıklı makale başarıyla eklenmiştir.";
            }

            public static string Delete(string talentName)
            {
                return $"{talentName} başlıklı makale başarıyla silinmiştir.";
            }
        }

        public static class Summary
        {
            public static string Update(string talentName)
            {
                return $"{talentName} başlıklı özet başarıyla güncellenmiştir.";
            }
        }

        public static class Education
        {
            public static string Add(string educationTitle)
            {
                return $"{educationTitle} başlıklı eğitim başarıyla eklenmiştir.";
            }

            public static string Delete(string educationTitle)
            {
                return $"{educationTitle} başlıklı eğitim başarıyla silinmiştir.";
            }
        }
        public static class Experience
        {
            public static string Add(string experienceTitle)
            {
                return $"{experienceTitle} başlıklı deneyim başarıyla eklenmiştir.";
            }

            public static string Delete(string experienceTitle)
            {
                return $"{experienceTitle} başlıklı deneyim başarıyla silinmiştir.";
            }
        }

    }
}
