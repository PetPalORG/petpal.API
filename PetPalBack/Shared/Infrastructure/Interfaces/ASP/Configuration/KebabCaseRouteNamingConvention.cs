﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;
using PetPalBack.shared.Interfaces.ASP.Configurations.Extensions;

namespace PetPalBack.shared.Infrastructure.Interfaces.ASP.Configurations
{
    public class KebabCaseRouteNamingConvention : IControllerModelConvention
    {
        private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
        {
            return selector.AttributeRouteModel != null ? new AttributeRouteModel
            {
                Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase())
            } : null;
        }
        public void Apply(ControllerModel controller)
        {
            foreach (var selector in controller.Selectors)
            {
                selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
            }

            foreach (var selector in controller.Actions.SelectMany(a => a.Selectors))
            {
                selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
            }
        }
    }
}