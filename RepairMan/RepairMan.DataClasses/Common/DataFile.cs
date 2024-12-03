// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RepairMan.DataClasses.Common
{
    public class DataFile
    {
        public Guid DataFileId { get; set; }

        public string ContentType { get; set; }

        [NotMapped, JsonIgnore]
        public byte[] Content { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }

        public long Length { get; set; }

        public User User { get; set; }
    }
}
