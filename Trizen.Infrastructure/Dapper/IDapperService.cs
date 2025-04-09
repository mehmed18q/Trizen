namespace Trizen.Infrastructure.Dapper;

public interface IDapperService<TParam, TRes> where TParam : class where TRes : class
{
    public Task<bool> Procedure(string procedure, TParam parameters);
    public Task<IEnumerable<TRestM>> Query<TRestM>(string query, TParam parameters);
    public Task<TRestM?> FirstResultQuery<TRestM>(string query, TParam parameters);
    public Task<(IEnumerable<T1>, IEnumerable<T2>)> MultiQuery<T1, T2>(string query, TParam parameters);
    public Task<(IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>)> MultiQuery<T1, T2, T3>(string query, TParam parameters);
    public Task<(IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>)> MultiQuery<T1, T2, T3, T4>(string query, TParam parameters);
    public Task<(IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>)> MultiQuery<T1, T2, T3, T4, T5, T6, T7>(string query, TParam parameters);
}
