using Microsoft.AspNetCore.Mvc;
using SmallErpNet_1.APIs.Common;
using SmallErpNet_1.Infrastructure.Models;

namespace SmallErpNet_1.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class UserFindManyArgs : FindManyInput<User, UserWhereInput> { }
