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

    }
}
