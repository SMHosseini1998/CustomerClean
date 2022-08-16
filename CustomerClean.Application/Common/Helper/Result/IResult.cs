using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Common.Helper.Result;
public interface IResult
{
    string Message { get; set; }

    bool Succeeded { get; set; }
}

public interface IResult<out T> : IResult
{
    T Data { get; }
}