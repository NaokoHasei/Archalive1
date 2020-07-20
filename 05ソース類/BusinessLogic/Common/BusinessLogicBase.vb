Imports System.Data
Public Interface IBusinessLogic
    'Function GetList(ByVal requestParam As BLL.Common.DTO.RequestSentakuKey) As DataSet
    Function GetList(ByVal requestParam As BLL.Common.DTO.RequestSentakuKey) As DataTable
    Function GetLeftList(ByVal requestParam As BLL.Common.DTO.RequestSentakuKey) As DataTable
    Function GetRightList(ByVal requestParam As BLL.Common.DTO.RequestSentakuKey) As DataTable
    Sub Update(ByVal requestParam As Model.DTO.RequestSentakuUpdate)
    Sub Insert(ByVal TableKey As Model.KobetuTableName, ByVal strPCNAME As String, ByVal strPGCODE As String, ByVal intFULINO As Integer)
    Sub Delete(ByVal TableKey As Model.KobetuTableName, ByVal strPCNAME As String, ByVal strPGCODE As String, ByVal intFULINO As Integer)
End Interface