using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GGPlatform.WebAPI.ModelDto
{
    public class RoleDto
    {
        [StringLength(50, ErrorMessage = "字节成度不能超过50")]
        [Required(ErrorMessage = "菜单名称不能为空！")]
        public string Name { get; set; }
        [Required(ErrorMessage = "菜单权限ID不能空！")]
        public string MenuPermissionID { get; set; }
    }
}
