using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "License",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    key = table.Column<string>(type: "TEXT", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    spdxid = table.Column<string>(name: "spdx_id", type: "TEXT", nullable: true),
                    url = table.Column<string>(type: "TEXT", nullable: true),
                    nodeid = table.Column<string>(name: "node_id", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    login = table.Column<string>(type: "TEXT", nullable: true),
                    nodeid = table.Column<string>(name: "node_id", type: "TEXT", nullable: true),
                    avatarurl = table.Column<string>(name: "avatar_url", type: "TEXT", nullable: true),
                    gravatarid = table.Column<string>(name: "gravatar_id", type: "TEXT", nullable: true),
                    url = table.Column<string>(type: "TEXT", nullable: true),
                    htmlurl = table.Column<string>(name: "html_url", type: "TEXT", nullable: true),
                    followersurl = table.Column<string>(name: "followers_url", type: "TEXT", nullable: true),
                    followingurl = table.Column<string>(name: "following_url", type: "TEXT", nullable: true),
                    gistsurl = table.Column<string>(name: "gists_url", type: "TEXT", nullable: true),
                    starredurl = table.Column<string>(name: "starred_url", type: "TEXT", nullable: true),
                    subscriptionsurl = table.Column<string>(name: "subscriptions_url", type: "TEXT", nullable: true),
                    organizationsurl = table.Column<string>(name: "organizations_url", type: "TEXT", nullable: true),
                    reposurl = table.Column<string>(name: "repos_url", type: "TEXT", nullable: true),
                    eventsurl = table.Column<string>(name: "events_url", type: "TEXT", nullable: true),
                    receivedeventsurl = table.Column<string>(name: "received_events_url", type: "TEXT", nullable: true),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    siteadmin = table.Column<bool>(name: "site_admin", type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GitHubRepositories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GitHubId = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    AvatarUrl = table.Column<string>(type: "TEXT", nullable: true),
                    nodeid = table.Column<string>(name: "node_id", type: "TEXT", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    fullname = table.Column<string>(name: "full_name", type: "TEXT", nullable: true),
                    @private = table.Column<bool>(name: "private", type: "INTEGER", nullable: true),
                    ownerId = table.Column<int>(type: "INTEGER", nullable: false),
                    htmlurl = table.Column<string>(name: "html_url", type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    fork = table.Column<bool>(type: "INTEGER", nullable: true),
                    url = table.Column<string>(type: "TEXT", nullable: true),
                    forksurl = table.Column<string>(name: "forks_url", type: "TEXT", nullable: true),
                    keysurl = table.Column<string>(name: "keys_url", type: "TEXT", nullable: true),
                    collaboratorsurl = table.Column<string>(name: "collaborators_url", type: "TEXT", nullable: true),
                    teamsurl = table.Column<string>(name: "teams_url", type: "TEXT", nullable: true),
                    hooksurl = table.Column<string>(name: "hooks_url", type: "TEXT", nullable: true),
                    issueeventsurl = table.Column<string>(name: "issue_events_url", type: "TEXT", nullable: true),
                    eventsurl = table.Column<string>(name: "events_url", type: "TEXT", nullable: true),
                    assigneesurl = table.Column<string>(name: "assignees_url", type: "TEXT", nullable: true),
                    branchesurl = table.Column<string>(name: "branches_url", type: "TEXT", nullable: true),
                    tagsurl = table.Column<string>(name: "tags_url", type: "TEXT", nullable: true),
                    blobsurl = table.Column<string>(name: "blobs_url", type: "TEXT", nullable: true),
                    gittagsurl = table.Column<string>(name: "git_tags_url", type: "TEXT", nullable: true),
                    gitrefsurl = table.Column<string>(name: "git_refs_url", type: "TEXT", nullable: true),
                    treesurl = table.Column<string>(name: "trees_url", type: "TEXT", nullable: true),
                    statusesurl = table.Column<string>(name: "statuses_url", type: "TEXT", nullable: true),
                    languagesurl = table.Column<string>(name: "languages_url", type: "TEXT", nullable: true),
                    stargazersurl = table.Column<string>(name: "stargazers_url", type: "TEXT", nullable: true),
                    contributorsurl = table.Column<string>(name: "contributors_url", type: "TEXT", nullable: true),
                    subscribersurl = table.Column<string>(name: "subscribers_url", type: "TEXT", nullable: true),
                    subscriptionurl = table.Column<string>(name: "subscription_url", type: "TEXT", nullable: true),
                    commitsurl = table.Column<string>(name: "commits_url", type: "TEXT", nullable: true),
                    gitcommitsurl = table.Column<string>(name: "git_commits_url", type: "TEXT", nullable: true),
                    commentsurl = table.Column<string>(name: "comments_url", type: "TEXT", nullable: true),
                    issuecommenturl = table.Column<string>(name: "issue_comment_url", type: "TEXT", nullable: true),
                    contentsurl = table.Column<string>(name: "contents_url", type: "TEXT", nullable: true),
                    compareurl = table.Column<string>(name: "compare_url", type: "TEXT", nullable: true),
                    mergesurl = table.Column<string>(name: "merges_url", type: "TEXT", nullable: true),
                    archiveurl = table.Column<string>(name: "archive_url", type: "TEXT", nullable: true),
                    downloadsurl = table.Column<string>(name: "downloads_url", type: "TEXT", nullable: true),
                    issuesurl = table.Column<string>(name: "issues_url", type: "TEXT", nullable: true),
                    pullsurl = table.Column<string>(name: "pulls_url", type: "TEXT", nullable: true),
                    milestonesurl = table.Column<string>(name: "milestones_url", type: "TEXT", nullable: true),
                    notificationsurl = table.Column<string>(name: "notifications_url", type: "TEXT", nullable: true),
                    labelsurl = table.Column<string>(name: "labels_url", type: "TEXT", nullable: true),
                    releasesurl = table.Column<string>(name: "releases_url", type: "TEXT", nullable: true),
                    deploymentsurl = table.Column<string>(name: "deployments_url", type: "TEXT", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "TEXT", nullable: true),
                    pushedat = table.Column<DateTime>(name: "pushed_at", type: "TEXT", nullable: true),
                    giturl = table.Column<string>(name: "git_url", type: "TEXT", nullable: true),
                    sshurl = table.Column<string>(name: "ssh_url", type: "TEXT", nullable: true),
                    cloneurl = table.Column<string>(name: "clone_url", type: "TEXT", nullable: true),
                    svnurl = table.Column<string>(name: "svn_url", type: "TEXT", nullable: true),
                    homepage = table.Column<string>(type: "TEXT", nullable: true),
                    size = table.Column<int>(type: "INTEGER", nullable: true),
                    stargazerscount = table.Column<int>(name: "stargazers_count", type: "INTEGER", nullable: true),
                    watcherscount = table.Column<int>(name: "watchers_count", type: "INTEGER", nullable: true),
                    language = table.Column<string>(type: "TEXT", nullable: true),
                    hasissues = table.Column<bool>(name: "has_issues", type: "INTEGER", nullable: true),
                    hasprojects = table.Column<bool>(name: "has_projects", type: "INTEGER", nullable: true),
                    hasdownloads = table.Column<bool>(name: "has_downloads", type: "INTEGER", nullable: true),
                    haswiki = table.Column<bool>(name: "has_wiki", type: "INTEGER", nullable: true),
                    haspages = table.Column<bool>(name: "has_pages", type: "INTEGER", nullable: true),
                    forkscount = table.Column<int>(name: "forks_count", type: "INTEGER", nullable: true),
                    mirrorurl = table.Column<string>(name: "mirror_url", type: "TEXT", nullable: true),
                    archived = table.Column<bool>(type: "INTEGER", nullable: true),
                    disabled = table.Column<bool>(type: "INTEGER", nullable: true),
                    openissuescount = table.Column<int>(name: "open_issues_count", type: "INTEGER", nullable: true),
                    licenseId = table.Column<int>(type: "INTEGER", nullable: true),
                    allowforking = table.Column<bool>(name: "allow_forking", type: "INTEGER", nullable: true),
                    istemplate = table.Column<bool>(name: "is_template", type: "INTEGER", nullable: true),
                    visibility = table.Column<string>(type: "TEXT", nullable: true),
                    forks = table.Column<int>(type: "INTEGER", nullable: true),
                    openissues = table.Column<int>(name: "open_issues", type: "INTEGER", nullable: true),
                    watchers = table.Column<int>(type: "INTEGER", nullable: true),
                    defaultbranch = table.Column<string>(name: "default_branch", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitHubRepositories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GitHubRepositories_License_licenseId",
                        column: x => x.licenseId,
                        principalTable: "License",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GitHubRepositories_Owners_ownerId",
                        column: x => x.ownerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GitHubRepositories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GitHubRepositories_licenseId",
                table: "GitHubRepositories",
                column: "licenseId");

            migrationBuilder.CreateIndex(
                name: "IX_GitHubRepositories_ownerId",
                table: "GitHubRepositories",
                column: "ownerId");

            migrationBuilder.CreateIndex(
                name: "IX_GitHubRepositories_UserId",
                table: "GitHubRepositories",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GitHubRepositories");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
