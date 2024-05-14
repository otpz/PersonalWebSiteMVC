namespace PersonalWebSiteMVC.Web.ResultMessages
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

        public static class Portfolio
        {
            public static string Add(string portfolioTitle)
            {
                return $"{portfolioTitle} başlıklı portfolyo başarıyla eklenmiştir.";
            }
            public static string Update(string portfolioTitle)
            {
                return $"{portfolioTitle} başlıklı portfolyo başarıyla güncellenmiştir.";
            }

            public static string Delete(string portfolioTitle)
            {
                return $"{portfolioTitle} başlıklı portfolyo başarıyla silinmiştir.";
            }
        }

        public static class Testimonial
        {
            public static string Add(string testimonialName)
            {
                return $"{testimonialName} isimli referans başarıyla eklenmiştir.";
            }

            public static string Delete(string testimonialName)
            {
                return $"{testimonialName} isimli referans başarıyla silinmiştir.";
            }
        }

        public static class SocialMedia
        {
            public static string Add(string socialMediaTitle)
            {
                return $"{socialMediaTitle} başlıklı sosyal medya başarıyla eklenmiştir.";
            }

            public static string Delete(string socialMediaTitle)
            {
                return $"{socialMediaTitle} başlıklı sosyal medya başarıyla silinmiştir.";
            }
        }

        public static class Contact
        {
            public static string Add(string contactSubject)
            {
                return $"{contactSubject} başlıklı iletişim formu başarıyla gönderilmiştir.";
            }

            public static string Delete(string contactSubject)
            {
                return $"{contactSubject} başlıklı iletişim formu başarıyla gönderilmiştir.";
            }
        }
    }
}
