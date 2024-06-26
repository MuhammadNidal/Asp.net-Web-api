using Fophex.Application.Shared.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Master.InstrumentTypes
{
    [Table(name: "InstrumentTypes", Schema = "account")]
    public class InstrumentType : AuditedEntity
    {
        public long  Id { get; set; }
        public string Name { get; set; }
    }
}
