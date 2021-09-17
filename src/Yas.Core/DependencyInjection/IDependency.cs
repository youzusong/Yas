namespace Yas.Core.DependencyInjection
{
    /// <summary>
    /// 依赖接口 - 瞬时模式
    /// </summary>
    public interface ITransientDependency
    { }

    /// <summary>
    /// 依赖接口 - 作用域模式
    /// </summary>
    public interface IScopedDependency
    { }

    /// <summary>
    /// 依赖接口 - 单例模式
    /// </summary>
    public interface ISingletonDependency
    { }
}
