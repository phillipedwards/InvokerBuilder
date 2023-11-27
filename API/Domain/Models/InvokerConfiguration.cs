using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class InvokerConfiguration
    {
        public long Id { get; set; }
        public Guid CompanyId { get; set; }
        public string? ApiSchema { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public int Version { get; set; }
    }

    public static class InvokerConfigurationExtensions
    {
        public static InvokerConfiguration Update( this InvokerConfiguration configuration, InvokerConfiguration input )
        {
            configuration.UpdatedOn = DateTime.UtcNow;
            configuration.UpdatedBy = !string.IsNullOrEmpty( input.UpdatedBy ) ? input.UpdatedBy : "System";
            configuration.ApiSchema = input.ApiSchema;
            configuration.Version = input.Version++;
            return configuration;
        }

        public static void ValidateOnCreate( this InvokerConfiguration configuration )
        {
            configuration.UpdatedOn = DateTime.UtcNow;
            configuration.CreatedOn = DateTime.UtcNow;
            configuration.CreatedBy = configuration.CreatedBy ?? "System";
            configuration.UpdatedBy = configuration.UpdatedBy ?? "System";
            configuration.Version = 1;
        }
    }
}
