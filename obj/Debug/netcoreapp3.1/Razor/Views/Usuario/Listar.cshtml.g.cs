#pragma checksum "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\Usuario\Listar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a41fcbf0c15796e289ab3dd3b0c26519e08cc009"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Listar), @"mvc.1.0.view", @"/Views/Usuario/Listar.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\_ViewImports.cshtml"
using ProjetoFullStack;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\_ViewImports.cshtml"
using ProjetoFullStack.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a41fcbf0c15796e289ab3dd3b0c26519e08cc009", @"/Views/Usuario/Listar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89e205d2ad9382e2623c0b489ebfa07a5ff7275c", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Listar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Usuario>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\Usuario\Listar.cshtml"
       ViewData["Title"] = "Listagem de Usuário"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h2>Listagem de usuario</h2>
<table>
    <thead>
        <tr>
            <th>Id</th>
            <th>Nome</th>
            <th>Login</th>
            <th>Senha</th>
            <th>Tipo</th>
            <th>Ações</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 16 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\Usuario\Listar.cshtml"
         foreach (Usuario i in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("           <tr>\r\n               <td>");
#nullable restore
#line 19 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\Usuario\Listar.cshtml"
              Write(i.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td>");
#nullable restore
#line 20 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\Usuario\Listar.cshtml"
              Write(i.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td>");
#nullable restore
#line 21 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\Usuario\Listar.cshtml"
              Write(i.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td>");
#nullable restore
#line 22 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\Usuario\Listar.cshtml"
              Write(i.Senha);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td>");
#nullable restore
#line 23 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\Usuario\Listar.cshtml"
              Write(i.Tipo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td>\r\n                   <a");
            BeginWriteAttribute("href", " href=\"", 628, "\"", 659, 2);
            WriteAttributeValue("", 635, "/Usuario/Editar?Id=", 635, 19, true);
#nullable restore
#line 25 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\Usuario\Listar.cshtml"
WriteAttributeValue("", 654, i.Id, 654, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">editar</a>\r\n                   <a");
            BeginWriteAttribute("href", " href=\"", 694, "\"", 726, 2);
            WriteAttributeValue("", 701, "/Usuario/Remover?Id=", 701, 20, true);
#nullable restore
#line 26 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\Usuario\Listar.cshtml"
WriteAttributeValue("", 721, i.Id, 721, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">remover</a>\r\n               </td>\r\n           </tr> \r\n");
#nullable restore
#line 29 "C:\Users\Fabrício\Documents\repositorio local git\ProjetoFullStack\Views\Usuario\Listar.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Usuario>> Html { get; private set; }
    }
}
#pragma warning restore 1591