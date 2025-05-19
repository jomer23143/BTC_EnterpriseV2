using System.Data;
using BTCP_EnterpriseV2.Utillities;

namespace BTC_EnterpriseV2.Class
{
    public class KitList
    {
        public static DataTable GetMoh(string mo_number)
        {
            DataTable dt = DataSupport.RunDataTableDapper($@"SELECT [mohId][mo_id]
	                  ,(Select ecoNum from MIBOMH where bomitem = m.buildItem and bomrev = m.bomrev)[pcn_number]
                      ,(Select descr from MIItem where itemid = m.buildItem)[description]
                      ,[locId][location]
                      ,[buildItem][bom_item] 
                      ,[bomRev][bom_revision_number]
                      ,[ordQty][order_quantity]
                      ,[ordDate][order_date]
                      ,''[kit_date]
                      ,[startDate][start_date]
                      ,[endDate][end_date]
                  FROM [MIMOH] m
                  where mohId = '{mo_number}'");
            return dt;
        }
        public static DataTable GetMoDetails(string mo_number)
        {
            DataTable dt = DataSupport.RunDataTableDapper($@"Select mohId[mo_id]
                ,lineNbr [item_number]
                ,item.ref [group]
                ,partId [ipn]
                ,item.descr [description]
                ,(case when item.type = 0 then 'Raw Material'
	                    when item.type = 1 then 'Resource'
	                    when item.type = 2 then 'Assembled'
	                    when item.type = 3 then 'Bulk Issue'
	                    when item.type = 4 then 'Outside Processing'
	                    end)[type]
                ,(Select mfgName from [MIQMFG] mfg where mfg.mfgId = item.mfgid and mfg.itemId = momd.partId)[manufacturing]
                ,(Select mfgProdCode from [MIQMFG] mfg where mfg.mfgId = item.mfgid and mfg.itemId = momd.partId)[manufacturing_product_code]
                ,srcLoc[source_location]
                ,'' as [stock]
                ,qty [unit_quantity]
                ,reqQty [mo_quantity]
                ,wipQty [wip_quantity]
                ,relQty [pick_quantity]
                ,'' [short_quantity]
                ,item.uOfm [unit]
                ,'' [invoice_number]
                ,'' [kitted]
                ,'' [individual_kitting]
                ,(case when item.track = 0 then 'Common Item - Not Tracked'
	                    when item.track = 1 then 'Lot Tracked'
	                    when item.track = 2 then 'Serialized'
	                    end) [track]
                ,'' [rack]
                ,momd.cmnt [comment]
                FROM [MIMOMD] momd
                join MIITEM item on item.itemId = momd.partId
                where mohId = '{mo_number}'");
            return dt;
        }
        public static DataTable GetMohDetails(string mo_number)
        {
            DataTable dt = DataSupport.RunDataTableDapper($@"SELECT m.[mohId][mo_id]
                ,(Select ecoNum from MIBOMH where bomitem = m.buildItem and bomrev = m.bomrev)[pcn_number]
                ,(Select descr from MIItem where itemid = m.buildItem)[description]
                ,m.[locId][location]
                ,m.[buildItem][bom_item] 
                ,m.[bomRev][bom_revision_number]
                ,m.[ordQty][order_quantity]
                ,m.[ordDate][order_date]
                ,''[kit_date]
                ,m.[startDate][start_date]
                ,m.[endDate][end_date]
                ,d.lineNbr [item_number]
                ,item.ref [group]
                ,d.partId [ipn]
                ,item.descr [description]
                ,(case when item.type = 0 then 'Raw Material'
	                    when item.type = 1 then 'Resource'
	                    when item.type = 2 then 'Assembled'
	                    when item.type = 3 then 'Bulk Issue'
	                    when item.type = 4 then 'Outside Processing'
	                    end)[type]
                ,(Select mfgName from [MIQMFG] mfg where mfg.mfgId = item.mfgid and mfg.itemId = d.partId)[manufacturing]
                ,(Select mfgProdCode from [MIQMFG] mfg where mfg.mfgId = item.mfgid and mfg.itemId = d.partId)[manufacturing_product_code]
                ,d.srcLoc[source_location]
                ,'' as [stock]
                ,d.qty [unit_quantity]
                ,d.reqQty [mo_quantity]
                ,d.wipQty [wip_quantity]
                ,d.relQty [pick_quantity]
                ,'' [short_quantity]
                ,item.uOfm [unit]
                ,'' [invoice_number]
                ,'' [kitted]
                ,'' [individual_kitting]
                ,(case when item.track = 0 then 'Common Item - Not Tracked'
	                    when item.track = 1 then 'Lot Tracked'
	                    when item.track = 2 then 'Serialized'
	                    end) [track]
                ,'' [rack]
                FROM [MIMOH] m join [MIMOMD] d on d.mohid = m.mohid
                join MIITEM item on item.itemId = d.partId
                where m.mohId ='{mo_number}'");
            return dt;
        }
        public static DataSet GetMohDetails_DS(string mo_number)
        {
            DataSet ds = DataSupport.RunDataSet($@"SELECT [mohId][mo_id]
	                  ,(Select ecoNum from MIBOMH where bomitem = m.buildItem and bomrev = m.bomrev)[pcn_number]
                      ,(Select descr from MIItem where itemid = m.buildItem)[description]
                      ,[locId][location]
                      ,[buildItem][bom_item] 
                      ,[bomRev][bom_revision_number]
                      ,[ordQty][order_quantity]
                      ,[ordDate][order_date]
                      ,''[kit_date]
                      ,[startDate][start_date]
                      ,[endDate][end_date]
                  FROM [MIMOH] m
                  where mohId = '{mo_number}';
                Select mohId[mo_id]
                ,lineNbr [item_number]
                ,item.ref [group]
                ,partId [ipn]
                ,item.descr [description]
                ,(case when item.type = 0 then 'Raw Material'
	                    when item.type = 1 then 'Resource'
	                    when item.type = 2 then 'Assembled'
	                    when item.type = 3 then 'Bulk Issue'
	                    when item.type = 4 then 'Outside Processing'
	                    end)[type]
                ,(Select mfgName from [MIQMFG] mfg where mfg.mfgId = item.mfgid and mfg.itemId = momd.partId)[manufacturing]
                ,(Select mfgProdCode from [MIQMFG] mfg where mfg.mfgId = item.mfgid and mfg.itemId = momd.partId)[manufacturing_product_code]
                ,srcLoc[source_location]
                ,'' as [stock]
                ,qty [unit_quantity]
                ,reqQty [mo_quantity]
                ,wipQty [wip_quantity]
                ,relQty [pick_quantity]
                ,'' [short_quantity]
                ,item.uOfm [unit]
                ,'' [invoice_number]
                ,'' [kitted]
                ,'' [individual_kitting]
                ,(case when item.track = 0 then 'Common Item - Not Tracked'
	                    when item.track = 1 then 'Lot Tracked'
	                    when item.track = 2 then 'Serialized'
	                    end) [track]
                ,'' [rack]
                ,momd.cmnt [comment]
                FROM [MIMOMD] momd
                join MIITEM item on item.itemId = momd.partId
                where mohId = '{mo_number}'");
            return ds;
        }
    }
}
