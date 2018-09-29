namespace ProductWebApplication.Statics
{
    using System;

    public static class StaticUser
    {
        private static Guid userId = new Guid("717a3ba7-6a7e-4c96-ad55-ef0728c579f1");

        public static Guid GetUserId()
        {
            return userId;
        }
    }
}
