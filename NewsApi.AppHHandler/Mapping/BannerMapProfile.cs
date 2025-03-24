using NewsAPI.Domain.AppEntity;
using NewsAPI.Domain.DTOS.BannersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.AppHandler.Mapping
{
    public static class BannerMapProfile
    {
        public static BannersReadDTO MapToBannersTOformReadDTO(this Banners platform)
        {
            return new BannersReadDTO
            {
                Id = platform.Id,
                Name = platform.Name,
                ImageUrl = platform.ImageUrl
            };
        }

        public static Banners MapToBannerCreateDtosTOBanners(this BannersCreateDto platform)
        {
            return new Banners
            {
                Name = platform.Name,
                ImageUrl = platform.ImageUrl
            };
        }

        public static IEnumerable<BannersReadDTO> ToPlatformReadDTOList(IEnumerable<Banners> banners)
        {
            return banners.Select(platform => platform.MapToBannersTOformReadDTO()).ToList();
        }
    }
}