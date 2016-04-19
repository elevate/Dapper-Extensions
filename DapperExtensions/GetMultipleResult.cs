using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;

namespace DapperExtensions
{
    public interface IMultipleResultReader
    {
        Task<IEnumerable<T>> Read<T>();
    }

    public class GridReaderResultReader : IMultipleResultReader
    {
        private readonly SqlMapper.GridReader _reader;

        public GridReaderResultReader(SqlMapper.GridReader reader)
        {
            _reader = reader;
        }

        public Task<IEnumerable<T>> Read<T>()
        {
            return _reader.ReadAsync<T>();
        }
    }

    public class SequenceReaderResultReader : IMultipleResultReader
    {
        private readonly Queue<SqlMapper.GridReader> _items;

        public SequenceReaderResultReader(IEnumerable<SqlMapper.GridReader> items)
        {
            _items = new Queue<SqlMapper.GridReader>(items);
        }

        public Task<IEnumerable<T>> Read<T>()
        {
            SqlMapper.GridReader reader = _items.Dequeue();
            return reader.ReadAsync<T>();
        }
    }
}