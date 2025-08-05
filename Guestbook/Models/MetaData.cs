using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guestbook.Models;

public class BookData
{
    [Display(Name = "編號")]
    [StringLength(36, MinimumLength = 36)]
    [Key]
    [HiddenInput]
    public string BookID { get; set; } = null;

    [Display(Name = "主題")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "主題內容為2~30個字")]
    [Required(ErrorMessage = "必填")]
    public string Title { get; set; } = null;

    [Display(Name = "內容")]
    [Required(ErrorMessage = "必填")]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; } = null;

    [Display(Name = "發表人")]
    [StringLength(10, ErrorMessage = "長度最多10個字元")]
    [Required(ErrorMessage = "必填")]
    public string Author { get; set; } = null;

    [Display(Name = "照片")]
    [StringLength(40)]
    public string? Photo { get; set; } = null;

    [Display(Name = "照片類型")]
    [StringLength(20)]
    public string? PhotoType { get; set; } = null;

    [Display(Name = "發表日期")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm:ss}")]
    [HiddenInput]
    public DateTime CreateDate { get; set; } = DateTime.Now;


   
}


public class RebookData
{

    [Display(Name = "編號")]
    [StringLength(36, MinimumLength = 36)]
    [Key]
    [HiddenInput]
    public string RebookID { get; set; } = null;


    [Display(Name = "回覆內容")]
    [Required(ErrorMessage = "必填")]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; } = null;


    [Display(Name = "回覆人")]
    [StringLength(10, ErrorMessage = "長度最多10個字元")]
    [Required(ErrorMessage = "必填")]
    public string Author { get; set; } = null;


    [Display(Name = "回覆時間")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm:ss}")]
    [HiddenInput]
    public DateTime CreateDate { get; set; } = DateTime.Now;



    [ForeignKey("Book")]
    [HiddenInput]
    public string BookID { get; set; } = null!;

}

[ModelMetadataType(typeof(BookData))]

public partial class Book
{

}

[ModelMetadataType(typeof(RebookData))]

public partial class Rebook
{

}
