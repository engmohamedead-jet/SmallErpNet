using Microsoft.AspNetCore.Mvc;
using SmallErpNet.APIs.Common;
using SmallErpNet.Infrastructure.Models;

namespace SmallErpNet.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class UserFindManyArgs : FindManyInput<User, UserWhereInput> { }
