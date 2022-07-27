// A part of the C# Language Syntactic Sugar suite.

namespace CLSS
{
  public static partial class ObjectAs
  {
    /// <summary>
    /// Casts to a different reference type, similarly to the as operator. This
    /// method has a boxing overhead.
    /// </summary>
    /// <typeparam name="R">The reference type to cast <paramref name="source"/>
    /// to.</typeparam>
    /// <param name="source"></param>
    /// <returns>The value of source casted to the specified reference type.
    /// </returns>
    public static R As<R>(this object source) where R : class
    { return source as R; }
  }
}