#%Apache%/conf/httpd-autoindex.conf
# Directives controlling the display of server-generated directory listings.
#
# Required modules: mod_autoindex, mod_alias
#
# To see the listing of a directory, the Options directive for the
# directory must include "Indexes", and the directory must not contain
# a file matching those listed in the DirectoryIndex directive.
#

#
# IndexOptions: Controls the appearance of server-generated directory
# listings.
#
IndexOptions FancyIndexing HTMLTable VersionSort

# We include the /icons/ alias for FancyIndexed directory listings.  If
# you do not use FancyIndexing, you may comment this out.
#
Alias /icons/ "%Apache%/icons/"

<Directory "%Apache%/icons">
    Options Indexes MultiViews
    AllowOverride None
    Require all granted
</Directory>

#
# AddIcon* directives tell the server which icon to show for different
# files or filename extensions.  These are only displayed for
# FancyIndexed directories.
#
AddIcon /icons/blank.png ^^BLANKICON^^
AddIcon /icons/folder.png ^^DIRECTORY^^
AddIcon /icons/folder-home.png ..

AddIconByType (TXT,/icons/text.png) text/*
AddIconByType (IMG,/icons/image.png) image/*
AddIconByType (SND,/icons/audio.png) audio/*
AddIconByType (VID,/icons/video.png) video/*

AddIcon /icons/archive.png .7z .bz2 .cab .gz .tar
AddIcon /icons/audio.png .aac .aif .aifc .aiff .ape .au .flac .iff .m4a .mid .mp3 .mpa .ra .wav .wma .f4a .f4b .oga .ogg .xm .it .s3m .mod
AddIcon /icons/bin.png .bin .hex
AddIcon /icons/bmp.png .bmp
AddIcon /icons/c.png .c
AddIcon /icons/calc.png .xlsx .xlsm .xltx .xltm .xlam .xlr .xls .csv
AddIcon /icons/cd.png .iso
AddIcon /icons/cpp.png .cpp
AddIcon /icons/css.png .css .sass .scss
AddIcon /icons/deb.png .deb
AddIcon /icons/doc.png .doc .docx .docm .dot .dotx .dotm .log .msg .odt .pages .rtf .tex .wpd .wps
AddIcon /icons/draw.png .svg .svgz
AddIcon /icons/eps.png .ai .eps
AddIcon /icons/exe.png .exe
AddIcon /icons/gif.png .gif
AddIcon /icons/h.png .h
AddIcon /icons/html.png .html .xhtml .shtml .htm .URL .url
AddIcon /icons/ico.png .ico
AddIcon /icons/java.png .jar
AddIcon /icons/jpg.png .jpg .jpeg .jpe
AddIcon /icons/js.png .js .json
AddIcon /icons/markdown.png .md
AddIcon /icons/package.png .pkg .dmg
AddIcon /icons/pdf.png .pdf
AddIcon /icons/php.png .php .phtml
AddIcon /icons/playlist.png .m3u .m3u8 .pls .pls8
AddIcon /icons/png.png .png
AddIcon /icons/ps.png .ps
AddIcon /icons/psd.png .psd
AddIcon /icons/py.png .py
AddIcon /icons/rar.png .rar
AddIcon /icons/rb.png .rb
AddIcon /icons/rpm.png .rpm
AddIcon /icons/rss.png .rss
AddIcon /icons/script.png .bat .cmd .sh
AddIcon /icons/sql.png .sql
AddIcon /icons/tiff.png .tiff .tif
AddIcon /icons/text.png .txt .nfo
AddIcon /icons/video.png .asf .asx .avi .flv .mkv .mov .mp4 .mpg .rm .srt .swf .vob .wmv .m4v .f4v .f4p .ogv
AddIcon /icons/xml.png .xml
AddIcon /icons/zip.png .zip

DefaultIcon /icons/default.png

ReadmeName /icons/footer.html
HeaderName /icons/header.html
IndexStyleSheet /icons/style.css

IndexIgnore .??* *~ *# HEADER* README* RCS CVS *,v *,t