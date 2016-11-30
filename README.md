# ASP.NET Core with Logging to ElasticSearch

This example is based on damienbod's [post](https://damienbod.com/2016/08/20/asp-net-core-logging-with-nlog-and-elasticsearch/) with some modifications:
* Changed `Layout.Render(logEvent)` in `ElasticSearchTarget::FormPayload` to render all properties as JSON for the `LogEventInfo`
