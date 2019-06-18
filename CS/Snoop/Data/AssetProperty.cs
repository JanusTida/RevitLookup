#if (V2018 || V2017)
#define LESS_THAN_2019
#endif

#if V2017
using ASTNameSpace = Autodesk.Revit.Utility;
#else
using ASTNameSpace = Autodesk.Revit.DB.Visual;
#endif

using Autodesk.Revit.DB;
using System.Collections;


namespace RevitLookup.Snoop.Data
{
    public class AssetProperty : Data
    {
        protected ASTNameSpace.AssetProperty m_val;
        protected Element m_elem;
        protected ASTNameSpace.AssetProperties m_assetProperties;

        public AssetProperty(string label,
            ASTNameSpace.AssetProperties assetProperties,
            ASTNameSpace.AssetProperty val) : base(label)
        {
            m_val = val;
            m_assetProperties = assetProperties;
        }


        public override bool 
            HasDrillDown
        {
            get
            {
                return m_assetProperties!=null && m_assetProperties.Size > 0;
            }
        }


        public override void DrillDown()
        {
            if (m_assetProperties != null)
            {
                ArrayList objs = new ArrayList();
                for (int i = 0; i < m_assetProperties.Size; i++)
                {
#if LESS_THAN_2019
                    objs.Add(m_assetProperties[i]);
#else
                    objs.Add(m_assetProperties.Get(i));
#endif
                }


                Snoop.Forms.Objects form = new Snoop.Forms.Objects(objs);
                form.ShowDialog();
            }
        }

       
        public override string StrValue()
        {
            return "<AssetProperty>";
        }
       
    }
}