using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MVCEmployeeModel
    { 

    public int UserId { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string UserAddress { get; set; }
    
    [Required]
    public string UserMobNo { get; set; }
}
}