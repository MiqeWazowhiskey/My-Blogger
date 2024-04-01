using System.Text;
using Microsoft.AspNetCore.Identity;

namespace My_Blogger.Middlewares;

public class AuthMiddleware
{
    /*
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context, SignInManager<IdentityUser> signInManager)
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            string authHeader = context.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                string encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                byte[] decodedBytes = Convert.FromBase64String(encodedUsernamePassword);
                string decodedText = Encoding.UTF8.GetString(decodedBytes);
                string[] usernamePasswordArray = decodedText.Split(':', 2);
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];
                
                var result = await signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    await _next.Invoke(context);
                    return;
                }
            }
            
            context.Response.StatusCode = 401;
            return;
        }
        
        await _next.Invoke(context);
    }
    */
}

