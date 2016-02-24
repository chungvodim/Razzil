using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Utils
{
    public static class DebugHelper
    {
        private static Logger _Logger = LogManager.GetCurrentClassLogger();
        public static void Error(Exception ex)
        {
            if (ex.GetType() == typeof(DbEntityValidationException))
            {
                foreach (var eve in (ex as DbEntityValidationException).EntityValidationErrors)
                {
                    _Logger.Error("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        _Logger.Error("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            else
            {
                _Logger.Error(ex);
            }
        }
    }
}
