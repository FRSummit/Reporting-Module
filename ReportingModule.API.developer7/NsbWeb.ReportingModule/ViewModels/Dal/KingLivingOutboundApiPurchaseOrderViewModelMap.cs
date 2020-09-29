using FluentNHibernate.Mapping;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class KingLivingOutboundApiPurchaseOrderViewModelMap : ClassMap<KingLivingOutboundApiPurchaseOrderViewModel>
    {
        public KingLivingOutboundApiPurchaseOrderViewModelMap()
        {
            Not.LazyLoad();
            ReadOnly();

            Table("KingLivingInterface_PoSendOperation");

            Id(x => x.OperationId).Column(nameof(KingLivingOutboundApiPurchaseOrderViewModel.OperationId));
            Map(x => x.CustomerPo);
            Map(x => x.Timestamp);

            Join("KingLivingInterface_PoSendApiPost",
                j =>
                {
                    j.Optional();
                    j.KeyColumn(nameof(KingLivingOutboundApiPurchaseOrderViewModel.OperationId));
                    j.Map(x => x.Url);
                    j.Map(x => x.ApiData);
                });

            HasMany(x => x.ErrorsInternal)
                .Not.LazyLoad()
                .Table("KingLivingInterface_PoSendError")
                .KeyColumn(nameof(KingLivingOutboundApiPurchaseOrderViewModel.OperationId))
                .Element("Error");

        }
    }
}
