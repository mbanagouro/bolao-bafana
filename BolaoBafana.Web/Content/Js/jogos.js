/*! jogos.js */
jQuery(function () {

    /* Contador */
    /*
    $('[data-timer]').each(function (index, el) {
    var $element = $(el),
    timer = $element.attr('data-timer');

    EncerrarApostas = function ($element) {
    console.log('acabou');
    $element.html('<span class="info">Apostas</span> <span class="destaque">Encerradas</span>')
    .parents('ul.jogo')
    .removeClass('aberto')
    .removeClass('finalizado')
    .addClass('encerrado')
    .find('li.apostas input.numerico')
    .prop('readonly', true);
    };

    SetCountdown = function ($element, until, format, layout, onTick, onExpiry) {
    $element.countdown({
    until: until,
    format: format,
    layout: '<span class="info">Apostas Encerram Em</span> <span class="destaque">' + layout + '</span>',
    onTick: onTick,
    onExpiry: onExpiry
    });
    };

    UpdateCountdown = function (timer) {
    var dias = 86400,
    horas = 3600,
    minutos = 0;

    if (timer > dias) {
    SetCountdown($element, timer, 'D', '{dnn} dia(s)', this.UpdateCountdown);
    } else if (timer > horas) {
    SetCountdown($element, timer, 'H', '{hnn} hora(s)', this.UpdateCountdown);
    } else if (timer > minutos) {
    SetCountdown($element, timer, 'M', '{mn} min', null, function () { EncerrarApostas($element); });
    } else {
    EncerrarApostas($element);
    }
    } (timer);

    });
    */

    $('[data-timer]').each(function (index, el) {
        var $element = $(el),
            timer = $element.attr('data-timer');

        EncerrarApostas = function ($element) {
            console.log('acabou');
            $element.html('<span class="info">Apostas</span> <span class="destaque">Encerradas</span>')
                    .parents('ul.jogo')
                    .removeClass('aberto')
                    .removeClass('finalizado')
                    .addClass('encerrado')
                    .find('li.apostas input.numerico')
                    .prop('readonly', true);
        };

        SetCountdown = function ($element, until, format, layout, onExpiry) {
            $element.countdown({
                until: until,
                format: format,
                layout: '<span class="info">Apostas Encerram Em</span> <span class="destaque">' + layout + '</span>',
                onExpiry: onExpiry
            });
        };

        UpdateCountdown = function (timer) {
            if (timer > 0) {
                SetCountdown($element, timer, 'HMS', '{hnn}:{mnn}:{snn}', function () { EncerrarApostas($element); });
            } else {
                EncerrarApostas($element);
            }
        } (timer);

    });

    /* Salvar Apostas */
    $('input.salvarApostas').click(function (e) {
        e.preventDefault(); e.stopPropagation();

        var $button = $(this),
            pai;

        var $form = $(this).parents('form');

        if ($button.parents('ul.jogo').length) {
            pai = $button.parents('ul.jogo');
        }

        if ($button.parents('.palpiteCampeao').length) {
            pai = $button.parents('.palpiteCampeao');
        }

        CriarFeedback(pai, $form);
    });

    function CriarFeedback(pai, $form) {
        pai.append('<div id="feedback"><div></div></div>');

        var fb = pai.find('div#feedback');
        fb.addClass('feedbackJogo').hide().fadeIn('fast');

        $.ajax({
            type: $form.attr('method'),
            url: $form.attr('action'),
            data: $form.serialize(),
            dataType: 'json',
            beforeSend: function () {
                AplicarMensagem(fb, "Aguarde. Salvando aposta...", false);
            },
            error: function () {
                AplicarMensagem(fb, "Não foi possível salvar a aposta!", true);
            },
            success: function (data) {
                if (data.Tipo === 'Jogo') {
                    $form.find('input[name="ApostaId"]').val(data.Id);
                } else if (data.Tipo === 'PalpiteCampeao') {
                    $form.find('input[name="PalpiteCampeaoId"]').val(data.Id);
                }
                AplicarMensagem(fb, "Aposta salva!", true);
            }
        });
    }

    function AplicarMensagem(fb, msg, timer) {
        var atualizar = false;

        if (fb.find('p').length) {
            fb.find('p').remove();
            atualizar = true;
        }

        if (timer) {
            setTimeout(function () {
                fb.fadeOut('fast', function () { RemoverFeedback(fb, true); });
            }, 1000);
        }

        fb.children('div').append('<p>' + msg + '</p>');

        if (atualizar) {
            fb.find('p').hide().fadeIn('fast');
        }

        // Posicionar Mensagem
        var spanY = fb.height() / 2 - fb.children('div').height() / 2;
        fb.children('div').css('top', spanY);
    }

    function RemoverFeedback(fb, esconderApostas) {
        var apostas = fb.parents('ul.jogo').find('li.apostas');
        fb.remove();
        if (esconderApostas) {
            setTimeout(function () { apostas.slideToggle(); }, 250);
        }
    }

    //Select mutuamente exclusivo (Palpites Campeões)
    $('select[id^=pc_]').change(function () {
        var selected = new Array();

        $('[id^=pc_] option:selected').each(function () {
            selected.push($(this).val());
        });

        $('[id^=pc_] option').each(function () {
            if (!$(this).is(':selected') && $(this).val() != '') {
                var shouldDisable = false;
                for (var i = 0; i < selected.length; i++) {
                    if (selected[i] == $(this).val())
                        shouldDisable = true;
                }

                $(this).css('text-decoration', '');
                $(this).removeAttr('disabled', 'disabled');
                if (shouldDisable) {
                    $(this).css('text-decoration', 'line-through');
                    $(this).attr('disabled', 'disabled');
                }
            }
        });
    })
    .trigger('change');

    //Radio mutualmente exclusivos (com names diferentes)
    $('span.campos').each(function () {
        var span = $(this),
            radios = span.find('input[type="radio"]');

        radios.click(function () {
            checkedState = $(this).attr('checked');
            $('input[name^=Palpite]:checked', span).each(function () {
                $(this).prop('checked', false);
            });
            $(this).prop('checked', checkedState);
        });
    });

});