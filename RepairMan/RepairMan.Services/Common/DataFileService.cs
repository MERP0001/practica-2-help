// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RepairMan.DataAccess;
using RepairMan.DataClasses.Common;

namespace RepairMan.Services.Common
{
    public class DataFileService : IDataFileService
    {
        private readonly RepairManContext _context;
        private readonly IConfiguration _configuration;

        public DataFileService(RepairManContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public DataFile Create(DataFile dataFile)
        {
            if (dataFile.Length == 0 || dataFile.Content == null || dataFile.Content.Length != dataFile.Length)
            {
                throw new ArgumentException("DataFile is empty");
            }

            if (!dataFile.ContentType.ToLower().Contains("image"))
            {
                throw new ArgumentException("DataFile is not an image");
            }

            _context.DataFiles.Add(dataFile);
            System.IO.File.WriteAllBytes(_configuration["ContentDirectory"] + "/" + dataFile.DataFileId.ToString(), dataFile.Content);
            _context.SaveChanges();
            return dataFile;
        }

        public DataFile GetFile(Guid id)
        {
            return this.GetFile(x => x.DataFileId == id);
        }

        public DataFile GetFile(Expression<Func<DataFile, bool>> predicate = null)
        {
            var dataFile = _context.DataFiles.FirstOrDefault(predicate);
            if (dataFile == null)
            {
                return null;
            }
            dataFile.Content = System.IO.File.ReadAllBytes(_configuration["ContentDirectory"] + "/" + dataFile.DataFileId.ToString());
            return dataFile;
        }
    }
}
