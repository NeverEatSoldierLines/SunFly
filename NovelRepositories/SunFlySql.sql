-- SQL脚本
create table AdminOperateRecords
(
    RecordId     int auto_increment
        primary key,
    OperatorType int         not null,
    OperateTime  datetime(6) not null,
    AdminTime    int         not null
);

create table EditorOperateRecords
(
    RecordId     int auto_increment
        primary key,
    OperatorType int         not null,
    OperateTime  datetime(6) not null,
    IsResigned   bit         not null
);

create table Novels
(
    NovelId             int auto_increment
        primary key,
    NovelName           longtext    not null,
    LastName            longtext    null,
    ShortDescription    longtext    not null,
    DetailedDescription longtext    not null,
    NovelTag            longtext    null,
    UserId              int         not null,
    FavoredNums         int         not null,
    CreatedTime         datetime(6) not null,
    LastAlterTime       datetime(6) not null,
    Score               double      not null
);

create table Chapters
(
    ChapterId      int auto_increment
        primary key,
    ChpterName     longtext not null,
    Shorthand      longtext not null,
    Content        longtext not null,
    NovelId        int      not null,
    BelongsNovelId int      not null,
    constraint FK_Chapters_Novels_NovelId
        foreign key (NovelId) references Novels (NovelId)
            on delete cascade
);

create table ChapterComments
(
    ChapterCommentId        int auto_increment
        primary key,
    UserId                  int         not null,
    Content                 longtext    not null,
    PublishTime             datetime(6) not null,
    BelongsChapterChapterId int         not null,
    constraint FK_ChapterComments_Chapters_BelongsChapterChapterId
        foreign key (BelongsChapterChapterId) references Chapters (ChapterId)
            on delete cascade
);

create index IX_ChapterComments_BelongsChapterChapterId
    on ChapterComments (BelongsChapterChapterId);

create index IX_Chapters_NovelId
    on Chapters (NovelId);

create table NovelComments
(
    NovelCommentId      int auto_increment
        primary key,
    UserId              int         not null,
    Content             longtext    not null,
    PublishTime         datetime(6) not null,
    BelongsNovelNovelId int         not null,
    constraint FK_NovelComments_Novels_BelongsNovelNovelId
        foreign key (BelongsNovelNovelId) references Novels (NovelId)
            on delete cascade
);

create index IX_NovelComments_BelongsNovelNovelId
    on NovelComments (BelongsNovelNovelId);

create table Users
(
    UserId           int auto_increment
        primary key,
    Username         longtext          not null,
    Email            longtext          not null,
    HeadLink         longtext          not null,
    RegisterTime     datetime(6)       not null,
    LastLoginTime    datetime(6)       not null,
    LastIp           int               not null,
    Role             int               not null,
    Status           smallint unsigned not null,
    Level            smallint unsigned not null,
    IsVip            bit               not null,
    SelfIntroduction longtext          null,
    TagList          longtext          null,
    WearTag          int               not null,
    Collections      longtext          null,
    Follows          longtext          null,
    Followed         longtext          null,
    ColorStone       int               not null,
    Feather          int               not null
);

create table Posts
(
    PostId            int auto_increment
        primary key,
    PostName          longtext    not null,
    PostContent       longtext    not null,
    PublishTime       datetime(6) not null,
    BelongsUserUserId int         not null,
    constraint FK_Posts_Users_BelongsUserUserId
        foreign key (BelongsUserUserId) references Users (UserId)
            on delete cascade
);

create table PostComments
(
    PostCommentId     int auto_increment
        primary key,
    UserId            int         not null,
    Content           longtext    not null,
    PublishTime       datetime(6) not null,
    BelongsPostPostId int         not null,
    constraint FK_PostComments_Posts_BelongsPostPostId
        foreign key (BelongsPostPostId) references Posts (PostId)
            on delete cascade
);

create index IX_PostComments_BelongsPostPostId
    on PostComments (BelongsPostPostId);

create index IX_Posts_BelongsUserUserId
    on Posts (BelongsUserUserId);

create table __EFMigrationsHistory
(
    MigrationId    varchar(150) not null
        primary key,
    ProductVersion varchar(32)  not null
);

