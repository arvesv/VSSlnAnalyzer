using Core;

namespace TestCore
{
    public class UnitTestCore
    {
        [Fact]
        public void NullLineGivesNullResult()
        {
            string? line = null;
            Assert.Null(SolutionFileTools.GetProjectPath(line));
        }

        [Fact]
        public void ExtractOneCSharpProject()
        {
            string line =
                "Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"Server.Foundation\", \"..\\Components\\Server\\Foundation\\Server.Foundation.csproj\", \"{1ACDA451-5D70-46F0-8252-4AF0ADBA51B3}\"";
            Assert.Equal("..\\Components\\Server\\Foundation\\Server.Foundation.csproj", Core.SolutionFileTools.GetProjectPath(line));
        }


        [Fact]
        public void ExtractAnotherCSharpProject()
        {
            string line =
                "Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"Interface.SystemAdministration\", \"..\\Components\\Interface\\SystemAdministration\\Interface.SystemAdministration.csproj\", ";
            Assert.Equal("..\\Components\\Interface\\SystemAdministration\\Interface.SystemAdministration.csproj", Core.SolutionFileTools.GetProjectPath(line));
        }


        [Fact]
        public void ReadTwoPrfojectsFromSLN()
        {
            string[] lines = """
                                Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "Common", "Common", "{ECEB7E29-5014-4588-A184-139093930C87}"
                EndProject
                Project("{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}") = "CommonLib", "..\Common\CommonLib\CommonLib.vcxproj", "{437B477F-0085-4BA8-ADBC-EE58A2630E82}"
                EndProject
                Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "Server.Foundation", "..\Components\Server\Foundation\Server.Foundation.csproj", "{1ACDA451-5D70-46F0-8252-4AF0ADBA51B3}"
                EndProject
                Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "TopGen.Common", "..\Components\TopGen\Common\TopGen.Common.csproj", "{0E291E31-12E1-41CD-98E9-D5A80D2BAC53}"
                	ProjectSection(ProjectDependencies) = postProject
                		{905D1959-6BAF-4E39-93D2-A41EB5261AA2} = {905D1959-6BAF-4E39-93D2-A41EB5261AA2}
                	EndProjectSection
                EndProject
                
                """.Split('\n');

            Assert.Equal(2,  Core.SolutionFileTools.GetCSharpProjects(lines).Length);
        }



    }
}