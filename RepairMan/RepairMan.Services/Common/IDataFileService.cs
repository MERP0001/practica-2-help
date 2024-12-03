// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Linq.Expressions;
using RepairMan.DataClasses.Common;

namespace RepairMan.Services.Common
{
    public interface IDataFileService
    {
        DataFile Create(DataFile dataFile);
        DataFile GetFile(Expression<Func<DataFile, bool>> predicate = null);
        DataFile GetFile(Guid id);
    }
}