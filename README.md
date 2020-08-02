# IssuesのJSONからIssuesの更新確認ベースモジュール

## 開発環境
* .NET Core 3.1以上

## 実行方法
ConsoleAppを実行する。  
```sh
# カレントディレクトリ：リポジトリルート
dotnet run --project ./source/ConsoleApp/ConsoleApp.csproj <IssuesAPI>
```
※IssuesAPI：[GitHub REST API v3 list-repository-issues](https://developer.github.com/v3/issues/#list-repository-issues)に対応したURI

## テスト方法
Testを実行する。  
```sh
# カレントディレクトリ：リポジトリルート
dotnet test ./source/Test/Test.csproj
```

## 仕様
### ConsoleAppで利用するIntrastructureの実装内容
* Intrastructure/ApiRepository.cs  
  * IApiRepositoryインターフェースの実装クラス
  * 指定するURIから取得したJSONをIssueEntityのリストにデシアライズして返す。
  * 想定するIssuesのJSONは[GitHub REST API v3](https://developer.github.com/v3/issues/#list-repository-issues)

* Intrastructure/IssueRepository.cs  
  * IIssueRepositoryインターフェースの実装クラス
  * IssuesEntityの永続化を担当する。
  * IssuesEntityをシリアライズしたローカルファイル「local.json」にて管理する。

### Domain層のエントリクラス(ApplicationService)
* Domain/Application/IssuesApplication.cs
  * IApiRepositoryとIIssueRepositoryをパラメータ経由で取得する。
  * DomainService(Domain/Issue/IssuesService)経由で最新Issuesを返す。
  * ドメインレイヤの知識を流出させないためにEntityを元にModel(IssueModel)を生成する。

### Domain層のDomainService(IssuesService)
* Domain/Domain/Issue/IssuesService.cs
  * ApiRepositoryから受け取った最新Issues(IssuesEntity)と保持している前回のIssuesと比較し、差分結果(IssuesEntity)を返す。
  * 最新Issues(IssuesEntity)をIssueRepositoryで永続化する。
