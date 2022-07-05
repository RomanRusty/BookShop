using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Contracts.ApiRoutes
{
    public static class ApiRoutes
    {
        private static readonly string BaseUrl = "https://localhost:6100/api/";

        public static class Books
        {
            private static readonly string ControllerUrl = string.Concat(BaseUrl, nameof(Books));

            public static readonly string GetAll = ControllerUrl;
            public static readonly string Get = string.Concat(ControllerUrl, "/{id}");
            public static readonly string Create = ControllerUrl;
            public static readonly string Update = string.Concat(ControllerUrl, "/{id}");
            public static readonly string Delete = string.Concat(ControllerUrl, "/{id}");
        }
        public static class Categories
        {
            private static readonly string ControllerUrl = string.Concat(BaseUrl, nameof(Categories));

            public static readonly string GetAll = ControllerUrl;
            public static readonly string Get = string.Concat(ControllerUrl, "/{id}");
            public static readonly string Create = ControllerUrl;
            public static readonly string Update = string.Concat(ControllerUrl, "/{id}");
            public static readonly string Delete = string.Concat(ControllerUrl, "/{id}");
        }
        public static class Auth
        {
            private static readonly string ControllerUrl = string.Concat(BaseUrl, nameof(Auth));

            public static readonly string Login = string.Concat(ControllerUrl, "/login");
            public static readonly string RegisterReader = string.Concat(ControllerUrl, "/register-reader");
            public static readonly string RegisterAuthor = string.Concat(ControllerUrl, "/register-author");
            public static readonly string RegisterAdmin = string.Concat(ControllerUrl, "/register-admin");
        }
    }
}
