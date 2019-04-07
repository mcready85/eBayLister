using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eBayLister.Models
{


    public class eBayItem
    {
        [Key]
        public int ItemID { get; set; }
        [Display(Name = "Item SKU")]
        public string ItemSKU { get; set; }     // Not required but needs to be generated if not supplied
        [Required]
        [MaxLength(80, ErrorMessage = "Title can not be longer than 80 characters")]
        public string Title { get; set; }    
        [Required]
        [Display(Name = "Category")]
        public Category CategoryType { get; set; } 
        [Required]
        [DataType(DataType.Currency)]
        [Range(1,100000,ErrorMessage = "Price cannot be greater than $100,000.")]
        public decimal Price { get; set; } 
        [Required]
        [Display(Name = "Condition")]
        public ConditionType Condition { get; set; } 
        [Required]
        [Display(Name = "Handling Time")]
        [Range(0,30,ErrorMessage = "Handling time cannot be greater than 30 days.")]
        public int HandlingTime { get; set; }   // 0 represents same day handling
        [Required]
        [Display(Name = "Listing Duration")]
        [Range(1,30,ErrorMessage = "Please select an option from list.")]
        public ListingTime Duration { get; set; } 
        [Required]
        [Display(Name = "Listing Type")]
        public ListingType Format { get; set; } 
        [Required]
        [Display(Name = "Picture URL")]
        public string PictureURL { get; set; }  // Will need to be adjusted to allow user to browse local files
        [Required]
        [Range(0,30,ErrorMessage ="Quantity cannot be greater than 1,000.")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

    }

    public enum ConditionType
    {
        New = 1,
        Used = 0
    }

    public enum ListingType
    {
        Auction = 0,
        [Display(Name = "Buy It Now")]
        BuyItNow = 1
    }

    public enum ListingTime
    {
        [Display(Name = "Choose...")]
        ZeroDay = 0, // blocked by range
        [Display(Name = "1 Day")]
        OneDay = 1,
        [Display(Name = "3 Days")]
        ThreeDay = 3,
        [Display(Name = "5 Days")]
        FiveDay = 5,
        [Display(Name = "7 Days")]
        SevenDay = 7,
        [Display(Name = "10 Days")]
        TenDay = 10,
        [Display(Name = "30 Days")]
        ThirtyDay = 30
        // Also GoodTilCancelled as option
    }

    public enum Category
    {
        
        Motors,
        Fashion,
        Electronics,
        [Display(Name = "Collectibles & Art")]
        CollectiblesArt,
        [Display(Name = "Home & Garden")]
        HomeGarden,
        [Display(Name = "Sporting Goods")]
        SportingGoods,
        [Display(Name = "Toys & Hobbies")]
        ToysHobbies,
        [Display(Name = "Business & Industrial")]
        BusinessIndustrial,
        Music

    }

}

/*
 * 
 Other things necessary for making API Call that should be set in user profile include:
 Country (assume US)
 Currency (assume USD)
 Postal Code (origin)
 Return Policy (whether or not returns are accepted, if so, days to return and method of return payment)
 Shipping Policy (UPS, USPS, FedEx, calculated or free)
 * 
 */
