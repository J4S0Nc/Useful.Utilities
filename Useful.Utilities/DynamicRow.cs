using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;

namespace Useful.Utilities
{
    /// <summary>
    /// Custom Dynamic Object for dealing with DataRow Objects
    /// </summary>
    public sealed class DynamicRow : DynamicObject
    {
        private readonly DataRow _row;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicRow"/> class.
        /// </summary>
        /// <param name="row">The data row object.</param>
        internal DynamicRow(DataRow row)
        {
            _row = row;
        }

        /// <summary>
        /// Gets the data row that created this DynamicRow object
        /// </summary>
        public DataRow DataRow
        {
            get { return _row; }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var retVal = _row.Table.Columns.Contains(binder.Name);
            result = retVal ? _row[binder.Name] : null;
            return retVal;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var retVal = _row.Table.Columns.Contains(binder.Name);
            if (retVal)
                _row[binder.Name] = value;
            return retVal;
        }

        /// <summary>
        /// Converts the specified table to Enumeration of <see cref="DynamicRow"/>.
        /// </summary>
        /// <param name="table">The data table to convert.</param>
        /// <returns>Enumeration of <see cref="DynamicRow"/></returns>
        public static IEnumerable<DynamicRow> Convert(DataTable table)
        {
            return from DataRow row in table.Rows select new DynamicRow(row);
        }
    }
}