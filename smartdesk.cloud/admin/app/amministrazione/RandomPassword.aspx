<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="RandomPassword.aspx.cs" Inherits="RandomPassword" %>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
  <div class="content-header">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-key fa-lg fa-fw"></i><%=strH1%></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      			  <a href="RandomPassword.aspx?azione=new" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Genera nuove password</a>
      			</div>
  	      </div>
      </div>
  </div>

<div class="grid-container fluid">
  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
      <div class="divform">
  			<div class="grid-x grid-padding-x">
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password1">1:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password1" id="password1" value="<%=strPassword1%>" data-password="<%=strPassword1%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password1',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password2">2:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password2" id="password2" value="<%=strPassword2%>" data-password="<%=strPassword2%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password2',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password3">3:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password3" id="password3" value="<%=strPassword3%>" data-password="<%=strPassword3%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password3',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			</div>
  			<div class="grid-x grid-padding-x">
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password4">4:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password4" id="password4" value="<%=strPassword4%>" data-password="<%=strPassword4%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password4',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password5">5:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password5" id="password5" value="<%=strPassword5%>" data-password="<%=strPassword5%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password5',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password6">6:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password6" id="password6" value="<%=strPassword6%>" data-password="<%=strPassword6%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password6',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			</div>
  			<div class="grid-x grid-padding-x">
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password7">7:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password7" id="password7" value="<%=strPassword7%>" data-password="<%=strPassword7%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password7',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password8">8:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password8" id="password8" value="<%=strPassword8%>" data-password="<%=strPassword8%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password8',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password9">9:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password9" id="password9" value="<%=strPassword9%>" data-password="<%=strPassword9%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password9',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			</div>
  			<div class="grid-x grid-padding-x">
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password10">10:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password10" id="password10" value="<%=strPassword10%>" data-password="<%=strPassword10%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password10',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password11">11:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password11" id="password11" value="<%=strPassword11%>" data-password="<%=strPassword11%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password11',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			  <div class="small-4 medium-2 large-1 cell">
  			  	<label class="large-text-right small-text-left middle" for="password12">12:</label>
  			  </div>
  			  <div class="small-8 medium-4 large-3 cell">
            <div class="input-group">
  			  	  <input type="text" name="password12" id="password12" value="<%=strPassword12%>" data-password="<%=strPassword12%>" class="input-group-field" />
              <div class="input-group-button">
                <button type="button" class="button" name="copia" onclick="copyToClipboard('password12',true)"><i class="fa-duotone fa-copy fa-fw"></i>Copia</button>
              </div>
            </div>
  			  </div>
  			</div>
  			<div class="grid-x grid-padding-x">
  			  <div class="small-12 medium-12 large-12 cell">
  				<div data-animate="fade-in fade-out" class="callout" data-closable>
  					<i class="fa-duotone fa-info-circle fa-fw fa-lg" style="--fa-primary-color: white;--fa-secondary-color: #0438a1;--fa-secondary-opacity: 1.0;"></i> Le password sono generate con i seguenti parametri:
  						<ul>
  					      <li>caratteri minuscoli: a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z</li>
  					      <li>caratteri maiuscoli: A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z</li>
  					      <li>numeri:1,2,3,4,5,6,7,8,9,0</li>
  					      <li>caratteri speciali: @,!,#,$,&,%,?,^,[,-,_</li>
  					      <li>lunghezza: 12 caratteri</li>
  					      <li>non riconducibile all'utente</li>
  					    </ul>
  					</div>
  				</div>
  			</div>
      </div>
    </div> 
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
