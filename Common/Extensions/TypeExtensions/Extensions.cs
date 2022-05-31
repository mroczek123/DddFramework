using System.Reflection;
using System.Runtime.ExceptionServices;

namespace Framework.Common.Extensions.TypeExtensions;

public static class Extensions
{
    public static object InvokeObjectMethod(this Type type, object objectRef, string methodName)
    {
        try
        {
            return type.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(objectRef, new object[] { });
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();    
            }
            throw;
        }
    }
}