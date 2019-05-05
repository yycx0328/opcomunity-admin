using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Opcomunity.Data.Entities
{
    public class TB_StatisticsChannelUserMap : EntityTypeConfiguration<TB_StatisticsChannelUser>
    {
        public TB_StatisticsChannelUserMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Date, t.Channel });

            // Properties
            this.Property(t => t.Channel)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("TB_StatisticsChannelUser");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Channel).HasColumnName("Channel");
            this.Property(t => t.RegistCount).HasColumnName("RegistCount");
            this.Property(t => t.ChargeMoney).HasColumnName("ChargeMoney");
            this.Property(t => t.ChargeUserCount).HasColumnName("ChargeUserCount");
            this.Property(t => t.CoinChargeMoney).HasColumnName("CoinChargeMoney");
            this.Property(t => t.CoinChargeUserCount).HasColumnName("CoinChargeUserCount");
            this.Property(t => t.VIPChargeMoney).HasColumnName("VIPChargeMoney");
            this.Property(t => t.VIPChargeUserCount).HasColumnName("VIPChargeUserCount");
            this.Property(t => t.TicketChargeMoney).HasColumnName("TicketChargeMoney");
            this.Property(t => t.TicketChargeUserCount).HasColumnName("TicketChargeUserCount");
            this.Property(t => t.ChatUserCount).HasColumnName("ChatUserCount");
        }
    }
}
