/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.plugins.addExternal('image2', '/Scripts/CKEditor/plugins/image2/', 'plugin.js');
CKEDITOR.plugins.addExternal('youtube', '/Scripts/CKEditor/plugins/youtube/', 'plugin.js');
CKEDITOR.plugins.addExternal('GoogleMap', '/Scripts/CKEditor/plugins/GoogleMap/', 'plugin.js');

CKEDITOR.editorConfig = function (config) {
	config.contentsCss = '/Content/defaultStyle.css';
	config.extraPlugins = 'uploadimage,image2,youtube,GoogleMap';
	config.pasteFromWordRemoveFontStyles = false;
	config.pasteFromWordRemoveStyles = false;
	config.allowedContent = true;
	config.toolbar = [
		{ name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Preview', 'NewPage', '-', 'Templates'] },
		{ name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
		{ name: 'editing', groups: ['find', 'selection', 'spellchecker'], items: ['Find', 'Replace', '-', 'SelectAll'] },
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'CopyFormatting', 'RemoveFormat'] },
		{ name: 'links', items: ['Link', 'Unlink', 'Youtube', 'GoogleMap'] },
		'/',
		{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'] },
		{ name: 'insert', items: ['Image', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'] },
		{ name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
		{ name: 'colors', items: ['TextColor', 'BGColor'] },
		{ name: 'tools', items: ['Maximize', 'ShowBlocks'] }
	];
	config.removePlugins = 'iframe';
	config.htmlEncodeOutput = true;
};

